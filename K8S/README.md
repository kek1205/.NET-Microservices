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

# Ingress nginx to apply deployment

`kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.7.0/deploy/static/provider/cloud/deploy.yaml`

# Get Pod by namespace

`kubectl get pod --namespace=ingress-nginx`
