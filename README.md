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

💥 Services are responsible to register themselves with Consul
💥 Combination of Rancher and Consul is used for Service Discovery so it is important that the names of the services match exactly. The workflow here is as follows:
*	When registering to Consul services use Rancher’s service discovery - link
*	Once they are registered OcelotGw uses this information to reroute, auth and authz 

## Identity Server

For development Id Server is deployed in Kubernetes with port mapping, but ideally it must have its own static IP.
Client Credentials Flow is used to request tokens. 

![Alt_Text](https://files.readme.io/447c445-client_credentials_flow.png)

Client_id, Client_secret, Scopes and Claims are stored in memory. These are further used by Ocelot to authenticate and authorize the client.



![Alt Text](http://g.recordit.co/2nvLlcMIEp.gif)
