clone this repo on local machine, to reduce size i have cleaned the solution and removed the binaries

Solution structure
  - src
        - Dunnhumby.Products
          - Dockerfile
        - Dunnhumby.Products.Test
  - sln
  - docker compose

Prequisite - docker for desktop or any docker hub cli access
go to docker-compose file location in power shell terminal and run below command 
   
**docker-compose up -d --build**
    
once containers are up and running, visit below url to see all api documentation and information
http://localhost:8080/swagger/index.html

as the env is still development we can utilise swagger ui for getting list of all apis

**Troubleshooting**
1. Go to SQL SSMS and try to connect to server - **localhost,1433**
   user name - **sa**
   password - **Mavuli@123**
    
