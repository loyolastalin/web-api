locally

docker build -t stalin-web-api .

docker run -d -p 8087:80 --name 1 firstapp

docker run -d -p 8087:80 --name stalin-myfirst-web1 loyolastalin/stalin-web-api:v1

> docker run -p 8082:80 -e ASPNETCORE_URLS=http://+:80 -e ASPNETCORE_ENVIRONMENT=Development loyolastalin/stalin-web-api:v4
>
> docker run -d -p 8083:80 -e ASPNETCORE_URLS=http://+:80 -e ASPNETCORE_ENVIRONMENT=Development  --name tesapp testimage
>
> docker run -d -p 8083:80 -e ASPNETCORE_ENVIRONMENT=Development --name test stalin-80-port

docker container

docker build -t loyolastalin/stalin-web-api:v2 .

docker push loyolastalin/stalin-web-api:v3

validate the container

docker exec -it first sh

minikube service web-api-service --url

az aks get-credentials --name demoaks --resource-group aks-prod
kubectl config current-context

kubectl apply -f k8s\

kubectl exec -it web-api-deployment-65d6966d94-qzpwp -- /bin/sh
