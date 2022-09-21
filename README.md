
# MMO Dragon Game Framework

Proof of concept for SpatialOS style entities and load balancing with distributed server workers. 

### Warning  

Probably should not try to use. This was all written quickly over the weekend after the whole issue with Unity and Improbable.  Might not even cover 1% of what a full mmo networking framework can do like SpatialOS.

## Tech
* C# Core
* Lidgren Networking
* MessagePack for Serialization

## Features

* Central server that handles message passing between the client and server workers.  
* An entity data store. Entities are the dynamic objects in the server. Entities have a list of data including position, type, and any game data needed.  
* MessagePack  for message passing to the client and server.  
* Example Unity3d client and server.  

## Future Work
* Add rotations.  
* Permissions for who can control what.
* Spread out the server workers.


![Server and Clients setup](https://img.youtube.com/vi/wfTIpBYMjlk/0.jpg)  

[Watch the video](https://youtu.be/wfTIpBYMjlk)  

# Important Links!

https://github.com/neuecc/MessagePack-CSharp#aot-code-generation-support-for-unityxamarin

## Setting up MessagePack Codegen
-i 
../packages/games.cookiedragon.mmogf.core/MmogfMessages
-o 
../packages/games.cookiedragon.mmogf.core/Scripts/Generated
-r
MmogfCoreResolver


### and

-i
MmogfMessages
-o
Scripts/Generated

# Docker Build

Build Server build in the `Builds/Linux` folder.  
Run in the main folder.  


`docker build -f Docker/Worker/Dockerfile -t judah4/dragongf-testgame:v0.0.9 -t judah4/dragongf-testgame:latest -t ghcr.io/judah4/testgame:v0.0.9 -t ghcr.io/judah4/testgame:latest .`

`docker build -f Docker/MainServer/Dockerfile -t judah4/dragongf:v0.0.9 -t judah4/dragongf:latest -t ghcr.io/judah4/dragongf:v0.0.9 -t ghcr.io/judah4/dragongf:latest .`

`docker compose -f Docker/Compose/docker-compose.yml up -d`

## Push

`docker push ghcr.io/judah4/testgame:v0.0.9`
`docker push ghcr.io/judah4/testgame:latest`
`docker push ghcr.io/judah4/dragongf:v0.0.9`
`docker push ghcr.io/judah4/dragongf:latest`

`docker push judah4/dragongf-testgame:latest`
`docker push judah4/dragongf-testgame:v0.0.9`
`docker push judah4/dragongf:latest`
`docker push judah4/dragongf:v0.0.9`

# Agones and Kubernetes

`kubectl create -f Agones/dragongf-gameserver.yaml`