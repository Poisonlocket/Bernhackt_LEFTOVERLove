# File ./Dockerfile
FROM node:22.7.0-alpine3.19 AS build

WORKDIR /app

COPY . .

RUN npm ci

RUN npm install -g @ionic/cli

ARG backend_domain
RUN sed -i 's|http://localhost:5000|'"https://$backend_domain"'|' /app/src/lib/client.ts

RUN ionic build

FROM nginx:1.27.1-alpine3.20

COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist /var/www/html/

RUN ls -al /var/www/html

ENTRYPOINT ["nginx","-g","daemon off;"]
