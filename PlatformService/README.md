# Docker Commands

### Buid an Image

`docker build -t <docker_hub_user_id>/platformservice`

### Push an Image to Docker Hub

`docker push <docker_hub_user_id>/platformservice`

### Run a Docker Image

`docker run -p 8080:80 -d <docker_hub_user_id>/platformservice`

### Stop a Running container

`docker stop <container_id>`

### Re-start a Container

`docker start <container_id>`
