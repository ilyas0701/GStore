FROM node:18-alpine AS build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

FROM node:18-alpine AS runner
WORKDIR /app

COPY --from=build /app ./

EXPOSE 3000
CMD ["npm", "start"]