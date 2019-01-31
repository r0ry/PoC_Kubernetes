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
*	Consul
**	Name: consul
**	Docker image: consul
** Publish port: 8500
*	OcelotGw
**	Name: ocelot
**	Docker image: r0ry/ocelotgw:v5
** Publish port: 80
*	Identity Server
**	Name: idserver
**	Docker image: r0ry/idserver:v4
**	Publish port: 80
**	💥 On listening port: 30412
*	CatalogApi
**	Name: catalog
** Docker image: r0ry/catalogapi:v1
**	Publish port: 80
*	ValuesApi
**	Name: values
**	Docker image: r0ry/valuesapi:v1
** Publish port: 80







:boom:
![Alt Text](http://g.recordit.co/2nvLlcMIEp.gif)
