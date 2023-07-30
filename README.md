# Ruckus Rummy (v0.0.0.0) - Pre versioning pre release

A self hosted open source planning pocker website written in React and .NET

## Notes

The website is built and run from a single docker image for portability. It uses nginx to proxy all traffic to 3 running web applications (2 currently runing) i.e. web, api and identity. 

- Paths starting {domain}/api will route to the api project
- Paths starting {domain}/identity will route to the identity project
- All other paths will route to the front end.

## TODO

- Finish adding support for Auth using IdentityServer
- Add support for connection to SQL database which swaps out in memory implementations of the repositories

## Dev Environment

cd ./RukusRummy.Api
dotnet watch run

Swagger is avaliable when runnning in the development environment at

http://localhost:5001/swagger

cd ./RukusRummy.Web
npm i
npm run start

http://localhost:3000/

## DOCKER

#### Building docker image

docker build -t ruckusrummy:latest .

#### Running Docker image

docker run -p 443-443 ruckusrummy