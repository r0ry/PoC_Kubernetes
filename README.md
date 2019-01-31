# PoC_Kubernetes


## Prerequisites

*	.Net Core 2.2
*	Docker (toolbox if working with VB)
*	VirtualBox
*	Vagrant
*	Postman (Testing) 

## Installation

Setup VMs
*	$ git clone https://github.com/r0ry/PoC_Kubernetes.git
*	$ cd ~/Rancher/vagrant 
*	$ vagrant up 
Setup Services
*	Open in browser 172.22.101.101 (may depend on your VM setup)
o	Default credentials: admin/admin 

*	Deploy workloads ( rancher docs ) 
NOTE: Consul needs to be deployed first and the values in the fields must match exactly for Service Discovery to work properly. This is explained further down.

![Alt Text](http://g.recordit.co/VGTwAzcq4A.gif)


|------------| Consul                 | OcelotGW                         | Identity Server                 | CatalogAPI                          | ValuesAPI                       |
|------------|------------------------|----------------------------------|---------------------------------|-------------------------------------|---------------------------------|
|Name        | consul           |	ocelot                    |	idserver                  |	catalog                       | values                    |
|Docker Image| consul   |	r0ry/ocelotgw:v5  |	r0ry/idserver:v4  | r0ry/catalogapi:v1    |	r0ry/valuesapi:v1 | 
|Publish Port| 8500     | 80                 |	80                | 80                    |  80               | 
|Listen Port |                        |                                  |	30412        |                                     |                                 |


## Service Discovery

*💥 Services are responsible to register themselves with Consul
*💥 Combination of Rancher and Consul is used for Service Discovery so it is important that the names of the services match exactly. The workflow here is as follows:
*	When registering to Consul services use Rancher’s service discovery - link
*	Once they are registered OcelotGw uses this information to reroute, auth and authz 

## Identity Server

For development Id Server is deployed in Kubernetes with port mapping, but ideally it must have its own static IP.
Client Credentials Flow is used to request tokens. 

![Alt_Text](https://i0.wp.com/www.bubblecode.net/wp-content/uploads/2013/03/client_credentials_flow.png?resize=525%2C396)

Client_id, Client_secret, Scopes and Claims are stored in memory. These are further used by Ocelot to authenticate and authorize the client.

## OcelotGateway  

Routing, Authentication and Authorization is done according to the docs: Ocelot

## Postman Testing

Request token from IdServer. Use Type OAuth 2.0 with parameters:
*	Grant Type: Client Credentials
*	Access Token URL: <idserver_ip/port>/connect/token
*	Client Id: ocelot
*	Client Secret: secret
*	Scope: gwapi
Http GET <ocelot_ip/port>/<endpoint>

![Alt Text](http://g.recordit.co/2nvLlcMIEp.gif)

## Current issues and suggestions 
1.	Tokens can be past in the header rather than asking for new 
a.	Example: Postman -> ValuesAPI -> CatalogAPI 
2.	Consul fails to deregister using CLI. Services are able to deregister themselves
3.	IdServer can use introspection endpoint to validate reference tokens
4.	Ocelot Gateway currently doesn’t support Swagger
5.	Each service currently registers to Consul. This is done using the same code sample in each service. A Registrar service may be helpful here.
6.	Deployment of services can be done using Helm

## Useful links

•	Security - https://github.com/freach/kubernetes-security-best-practice
•	Learn - https://github.com/burrsutter/9stepsawesome
•	Examples:
o	https://github.com/EdwinVW/pitstop
o	https://github.com/dotnet-architecture/eShopOnContainers
•	Videos:
o	https://www.youtube.com/channel/UCc3apIciZhgTUw_kk6C9EJQ/videos

