﻿using System;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace HelloSmartContracts
{
    public class Domain : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "query":
                    return Query((string)args[0]);
                case "register":
                    return Register((string)args[0], (byte[])args[1]);
                case "transfer":
                    return Transfer((string)args[0], (byte[])args[1]);
                case "delete":
                    return Delete((string)args[0]);
                default:
                    return false;
            }
        }

        private static object Transfer(string domain, byte[] to)
        {
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, domain);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, domain, to);
            return true;
        }

        private static object Register(string domain, byte[] owner)
        {
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        private static object Delete(string domain)
        {
            byte[] owner = Storage.Get(Storage.CurrentContext, domain);
            if (owner == null) return false;
            if (!Runtime.CheckWitness(owner)) return false;
            Storage.Delete(Storage.CurrentContext, domain);
            return true;
        }

        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }
    }
}
