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


| Consul                 | OcelotGW                         | Identity Server                 | CatalogAPI                          | ValuesAPI                         |
|	Name: consul           |	Name: ocelot                    |	Name: idserver                  |*	Name: catalog                     |*	Name: values                    |
|	Docker image: consul   |	Docker image: r0ry/ocelotgw:v5  |	Docker image: r0ry/idserver:v4  |* Docker image: r0ry/catalogapi:v1   |*	Docker image: r0ry/valuesapi:v1 | 
| Publish port: 8500     | Publish port: 80                 |	Publish port: 80                |*	Publish port: 80                  |*  Publish port: 80                | 
|                        |                                  |	On listening port: 30412        |                                     |                                   |



| First Header  | Second Header |
| ------------- | ------------- |
| Content Cell  | Content Cell  |
| Content Cell  | Content Cell  |



:boom:
![Alt Text](http://g.recordit.co/2nvLlcMIEp.gif)
