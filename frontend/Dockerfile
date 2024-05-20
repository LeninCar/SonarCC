FROM node:19-alpine

WORKDIR /app

RUN addgroup -S nonroot \
    && adduser -S nonroot -G nonroot

COPY package*.json ./

RUN npm install --ignore-scripts

COPY src/ ./src/
COPY public/ ./public/

RUN npm run build

EXPOSE 3000

USER nonroot

CMD ["npm", "start"]
