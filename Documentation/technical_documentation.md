# Team LeftoverLove / Stop Foodwaste Challenge Bärnhäckt 2024

___

## Aktueller Stand des Sourcecodes

[Github Link](https://github.com/Poisonlocket/Bernhackt_LEFTOVERLove "link to github repo")

## Ausgangslage

Foodwaste, zu deutsch Lebensmittelverschwendung ist ein Problem, das uns alle betrifft. Foodwaste zu verhindern, ist eines der globalen Sustainability Goals der UN [Details](https://sdgs.un.org/topics/sustainable-consumption-and-production "sustainability goals"). Die Schweiz hat sich dazu verpflichet, dieses Ziel zu erreichen. Doch neuere Zahlen zeigen, dass wir noch immer alle zusammen an diesem Thema arbeiten müssen. 2017 zeigte eine schweizer Studie der ETH [Link](https://www.swissinfo.ch/eng/society/stop-the-rot-_survey-reveals-full-impact-of-swiss-food-waste/45324664 "food waste study 2017"), dass die Hälfte der Lebensmittelverschwendung durch Haushalte verursacht werden. Auch die neusten Zahlen geben keine Entwarnung; der Foodwaste ging kaum zurück und die Lebensmittel, die im Abfall von Haushalten landen, machen immernoch rund 38% aus [Link](https://www.bafu.admin.ch/bafu/de/home/themen/abfall/abfallwegweiser-a-z/biogene-abfaelle/abfallarten/lebensmittelabfaelle.html "link zahlen 2024"). Somit sind die Haushalte leider führend im Verschwenden von Lebensmitteln. Aber warum? Lebensmittelverschwendung in Haushalten wird durch eine Kombination aus Verhaltensweisen (zB Essensplanung, Protionsgrössen), Wissenslücken (zB Fehlverständnis vom Haltbarkeitsdatum) und wirtschaftlichen Faktoren (zB Promotionen auf Grosspackungen) beeinflusst. Es gibt bereits Foodsharing Angebote wie das Foodsharing-Network [Link](https://foodsharing.network/ "foodsharing network") oder Madame Frigo [Link](https://www.madamefrigo.ch/de/ "Madame Frigo"). Dies ist bereits ein sehr guter Vorstoss und soll auf keinen Fall konkurriert werden. Dennoch bedingen solche Sharingplattformen einiges an Logistik (zB fixe Standorte). Unsere Idee soll solche Angebote ergänzen und jedem Mensch so einfach wie möglich Foodsharing zugänglich machen.

## Zusammenfassung

Am diesjährigen BärnHäckt arbeitet Team **LEFTOVERLove** an der Challenge von Transgourmet ([Challenge](https://www.bernhackt.ch/challenges/2024-stopfoodwaste "challenge  dscription")), um **Transgourmet** beim Bekämpfen von Foodwaste zu helfen. Dies hilf, Lebensmittelverschwendung und die resultierenden Kosten, sowie den negativen Impakt auf die Umwelt, zu verhindern. Wir entwickelten eine Applikation, wo man mit einem klick seine zu rettenden Lebensmittel hochladen kann. Ein/e Retter/in kann mit einem Klick weiderum die Lebensmittel abholen. Die Lösung reiht sich nahtlos an bestehende Anti-Foodwaste Initiativen an, ohne diese zu kanibalisieren. Dabei vereint unsere Lösung ein unkompliziertes und dezetralisiertes Verteilen von Essen, das sonst weggeworfen würde, und bietet sowohl Menschen, die punktuell zu viel Essen zu Hause haben, und Menschen, die Essen retten wollen einen Mehrwert.

### Problembeschrieb

* Marie geht in die Ferien. Sie hat aber noch Früchte zu Hause, die sie nicht verwerten kann und wegschmissen müssten.
* Oleg ist Student und hat ein schmales Budget. Er freut sich über die Chance Essen zu retten und dabei seinen Geldbeutel zu schonen.
* Marie und Oleg kennen sich nicht, könnten sich aber gegenseitig helfen, Essen vor dem Mülleimer zu Retten und dabei das Budget zu schonen.

### Fokus

MVP fokussiert sich auf EINFACHHEIT für die Menschen, die Essen "voorig" haben, und Menschen, welche die Retter/innen des Essens sind.

### Technische Grundsatzentscheide

* Bewusster Entscheid für Mobile
* Personenbezogene Daten werden auf das Minimum reduziert verwendet

## Technischer Aufbau

### Komponenten und Frameworks

- ASPNet Core
- Entity Framework
- Automapper
- VueJS with Ionic

<img src="project_images/Architecture.png" alt="Architecture">

### Aufgabe pro Tool

* C# / ASPNet Core: Backend
* Entity Framework: DB Models
* Automapper: Mapping Models to DTOs
* VueJS: Frontend

### Funktionen der App

- Fotografieren von Lebensmitteln (alternativ Upload)
- Anzeige der zu rettenden Lebensmittel
- Karte mit den räumlich zu dir am nächsten zu rettenden Lebensmitteln
- Berechnung mit räumlichen Distanz mit Haversine-Algorithmus

## Implementation

Web-basierter PoC. Wir verwenden das Ionic Framework, womit man ein Moblieapp plattformunabhängig entwickeln kann. Die App ist einfach und selbsterklärend gestaltet, um die Einstiegshürde für alle Benutzer/innen so tief wie möglich zu halten. Als Anbieter von Lebensmitteln kann man mit einem Foto die Lebensmittel anbieten. Die Geolocation wird automatisch daraus extrahiert. Als Retter/in der Lebensmittel kann man per Map oder Liste die Lebensmittel am nächsten zum jetzigen Standort finden und reservieren. Anbieter/in und Retter/in kann eine oder beide Rollen einnehmen, ohne die App zu wechseln oder neu anzumelden. Keep it simple!

### Out of Scope

* Chat für die Anbieter und Retter/innen
* Wiki zum Thema Foodwaste
* Tutorial zur Applikation

### Zukunftsplan

* Machine-Vision zum Erkennen der Produkte auf dem Foto
* Klimaschutzrelevante Daten anzeigen: zB gespartes CO<sub>2
* Gamification-Ideen

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

## API Referenz

Swagger der FastAPI.

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

## Mitwirkende

- Yasin Gündüz
- Christian Huber
- Matthias Oberholzer
- Lorenzo Bonometti
- Florence Meier

___

:heart: :banana: :computer: :bear: :switzerland: