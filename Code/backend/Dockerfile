# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./ .
RUN dotnet restore

# add frontend domain
ARG frontend_domain
RUN sed -i 's|{FRONTEND_DOMAIN}|'"$frontend_domain"'|' LeftOverLove.WebAPI/Startup/CorsStartup.cs

# build app
WORKDIR /source/LeftOverLove.WebAPI
RUN dotnet publish -c release -o /app --no-restore

# create image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "LeftOverLove.WebAPI.dll"]
