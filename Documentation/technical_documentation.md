# Team LEFTOVERLove | Stop Foodwaste Challenge Bärnhäckt 2024

___

## Aktueller Stand des Quellkodes

[Github Link](https://github.com/Poisonlocket/Bernhackt_LEFTOVERLove "link to github repo")

## Inhaltsverzeichnis

1. [Einführung](#einführung)
2. [Installation Frontend](#installation-frontend)
3. [Benutzung](#benutzung)
    - [Funktionen](#funktionen)
    - [Beispiele](#beispiele)
4. [Installation Backend](#installation-backend)
5. [Benutzung](#benutzung)
    - [Funktionen](#funktionen)
    - [Beispiele](#beispiele)
6. [API-Referenz](#api-referenz)
    - [Lokal](#lokal)

## Einführung

Hallo Freunde! Mit unserer App ist es kinderleicht Lebensmittel zu retten. Probiere es aus.

## Installation Frontend

### Voraussetzungen

- PNPM installed: `npm install -g pnpm` or `brew install pnpm`
- [PNPM Installation](https://pnpm.io/installation)
- Ionic installed globally: `npm install -g @ionic/cli@latest native-run`

### Schritte

``` bash
git clone [url]
cd frontend
pnpm install
ionic serve
```

Datenbank Zugriff

- Postgres Database (v 16.2)
- Database Name: `leftoverlove`
- User: `root`
- Password: `password`
- Port: `2308`

## Installation Backend

### Voraussetzungen

- Docker: [Docker](https://docs.docker.com/get-docker/)
- .NET Version 8
- .NET EF (commandline tool): `dotnet tool install dotnet-ef -g --version 8.0.4`
- Füge Host Entries hinzu `127.0.0.1 leftoverlove.db` -> `/etc/hosts` (Linux/Mac) oder
  `C:\Windows\System32\drivers\etc\hosts` (Windows)

### Schritte

``` bash
cd ./backend
docker compose up -d
run database migration  # nur das erste Mal
```

## Benutzung

TODO LINKS

Gehe auf XXX. Du siehst die Ansicht des Anbieters für Lebensmittel, die gerettet werden können. Mach ein Foto und trage
das Haltbarkeitsdatum ein. Als Retter/in, gehe auf XXX. Dort siehst du die Lebensmittel, die zum Retter in deiner
Umgebung bereitstehen. Wähle eines aus.

### Funktionen

- Fotografieren von Lebensmitteln
- Anzeige der zu rettenden Lebensmittel
- Karte mit den räumlich zu dir am nächsten zu rettenden Lebensmitteln

### Beispiele

Lorem ipsum

## API Referenz

TODO: ADD LINK TO SWAGGER
XXX

### Lokal
OpenAPI Client generieren (Docker und ZSH)

``` bash
cd frontend
docker run --rm \
  -v ${PWD}:/local openapitools/openapi-generator-cli generate \
  -i /local/openapi.yml \
  -g typescript-fetch \
  -o /local/src/lib/leftoverlove_client

```

- Hostname: `localhost`
- Port `5000`