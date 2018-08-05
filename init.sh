rm -rf output
rm -rf testlib

git submodule update
cd ./HelloSmartContracts
dotnet clean
dotnet publish -o ../testlib
cd ..

cd  ./neo-compiler/neon
dotnet clean
dotnet publish -o ../../testlib
cd ../..

# compile neo contract to avm
cd testlib
dotnet ./neon.dll ./HelloSmartContracts.dll
cd ..

mkdir output
cp ./testlib/HelloSmartContracts.avm ./output/HelloSmartContracts.avm