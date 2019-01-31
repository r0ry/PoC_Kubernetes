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

![Alt_Text](data:image/png;base64,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)

Client_id, Client_secret, Scopes and Claims are stored in memory. These are further used by Ocelot to authenticate and authorize the client.



![Alt Text](http://g.recordit.co/2nvLlcMIEp.gif)
