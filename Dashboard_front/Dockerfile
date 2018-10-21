FROM node

WORKDIR /webapp

COPY package*.json /webapp/

RUN npm install -v

ENV PORT=80

COPY . .

EXPOSE 80

CMD [ "npm", "start" ]
