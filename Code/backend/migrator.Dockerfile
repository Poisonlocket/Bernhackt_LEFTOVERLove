FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source

COPY ./ .

ENV PATH="${PATH}:~/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef --version 8.0.8

# https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.NETCore.Platforms/src/runtime.json
# alpine-x64 doesn't work, possibly because of a bug in dotnet
RUN dotnet ef migrations bundle --project LeftOverLove.DataAccess --startup-project LeftOverLove.WebAPI --self-contained -r linux-musl-x64 --verbose

FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine

WORKDIR /migration

COPY --from=build /source/efbundle ./efbundle
COPY --from=build /source/LeftOverLove.WebAPI/appsettings.json ./appsettings.json

ENTRYPOINT [ "./efbundle" ]
