# Kubernets Commands

## Apply a "file"

`kubectl apply -f <name of file>`

## Get Deployments

`kubectl get deployments`

## Get pods

`kubectl get pod`

## Get All Namespaces

`kubectl get namespace`

## Delete an deployment

`kubectl delete deployment plaforms-depl`

## Restart Deployment

`kubectl rollout restart deployment platforms-depl`

## Ingress nginx to apply deployment

`kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.7.0/deploy/static/provider/cloud/deploy.yaml`

## Delete all pod with namespace

`kubectl get pod --namespace=ingress-nginx`

## Get Pod by namespace

`kubectl get pod --namespace=ingress-nginx`

## Get Persistence claim

`kubectl get pvc`

## Get Storage class

`kubectl get storageclass`

## Create Secret key for Mssql

`kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55wOrd!"`
