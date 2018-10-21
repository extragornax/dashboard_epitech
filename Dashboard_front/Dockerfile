FROM node

WORKDIR /webapp

COPY package*.json /webapp/

RUN npm install -v

ENV PORT=3000

COPY . .

EXPOSE 3000

CMD [ "npm", "start" ]
