sudo docker pull cityofzion/neo-privatenet
sudo docker run -d --rm --name neo-privnet -p 20333-20336:20333-20336/tcp -p 30333-30336:30333-30336/tcp cityofzion/neo-privatenet
