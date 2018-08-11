# HelloSmartContracts
First smart contract on NEO 

Steps:

1. Build the smart contract
```bash
./build.sh
```
2. Run the docker `cityofzion/neo-privatenet` container

```bash
docker run -d --name neo-privatenet -p 20333-20336:20333-20336/tcp -p 30333-30336:30333-30336/tcp -v "$(pwd)/output":/neo-python/smartContracts cityofzion/neo-privatenet
```
3. Get inside the docker container and start a bash shell

```bash
docker exec -it neo-privatenet /bin/bash
```

4. Start neopy and open wallet
```bash
neopy
```
```bash
open wallet neo-privnet.wallet
```

5. Import new smart contract
```bash
import contract ./smartContracts/HelloSmartContracts.avm 0710 01 True False
``` 

6. Search for the contract
```bash
contract search DomainContract
```