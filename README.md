# Team LEFTOVERLove | Challenge Lebensmittel weitergeben statt wegwerfen (Transgourmet)

## Documentation

[BärnHäckt - Project Project Documentation](./project_documentation.md)

## Prerequisites

- PNPM installed: `npm install -g pnpm` or `brew install pnpm`
- [PNPM Installation](https://pnpm.io/installation)
- Ionic installed globally: `npm install -g @ionic/cli@latest native-run`

## How to start frontend

1. Clone the repository with `git clone [url]`
2. Go to frontend folder `cd frontend`
3. Run dependencies with `pnpm install`
4. Start ionic project with `ionic serve`

## Development

- Backend Code is in `./backend` folder
- Frontend Code is in `./frontend` folder

# Demo
[TODO ADD LINK TO DEMO] -> GENERATE QRCODE FOR DEMO / HOSTING


## CI / Pipelines

## Generate openapi client

With Docker (zsh):

```sh
cd frontend
```

```sh
docker run --rm \
  -v ${PWD}:/local openapitools/openapi-generator-cli generate \
  -i /local/openapi.yml \
  -g typescript-fetch \
  -o /local/src/lib/leftoverlove_client
```

Note: if using zsh shell it is `{$PWD}` instead of `${PWD}`.

---

## Authors
- [Github Christian Huber](https://github.com/jarheadcore)
- [Github Yasin Gündüz](https://github.com/yguenduez)
- [Github Matthias Oberholzer](https://github.com/githubUser3454321)
- [Github Lorenzo Bonometti](https://github.com/Poisonlocket)
- [Github Florence Meier](https://github.com/Tamalera)
