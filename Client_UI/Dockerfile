FROM node:16-alpine

WORKDIR /app

# Copy package files and install dependencies
COPY Compliance.UI/package.json Compliance.UI/package-lock.json ./
RUN npm ci

# Copy the rest of the application and build it
COPY Compliance.UI ./
RUN npm run build
EXPOSE 4200

CMD ["npm", "start"]