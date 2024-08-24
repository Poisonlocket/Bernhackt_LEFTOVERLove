# Left Over Love Backend

## Prerequisites
- Docker installed: [Docker](https://docs.docker.com/get-docker/)
- .NET Version 8 installed
- .NET EF (commandline tool) installed: `dotnet tool install dotnet-ef -g --version 8.0.4`
- Add Host Entries `127.0.0.1 leftoverlove.db` -> `/etc/hosts` (Linux/Mac) or `C:\Windows\System32\drivers\etc\hosts` (Windows)

## Steps to init
- cd `./backend` folder (if not already there ;D), then run `docker compose up -d`
- First / Init start: run database migration

## Database
- Postgres Database (v 16.2)
- Database Name: `leftoverlove`
- User: `root`
- Password: `password`
- Port: `2308`

## API Backend
- Hostname: `localhost`
- Port `5000`

### Create Migration

``` shell
dotnet ef migrations add Initial --project LeftOverLove.DataAccess --startup-project LeftOverLove.WebAPI/
```

### Update Database

``` shell
dotnet ef database update --project LeftOverLove.WebAPI/
```
