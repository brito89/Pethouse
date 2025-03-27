# Use Node.js base image
FROM node:lts AS build

# Set working directory
WORKDIR /app

# Copy package files and install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the application files
COPY . .

# Build the application
RUN npm run build

# Use Nginx as the server
FROM nginx:stable
COPY --from=build /app/dist/pethouse-client/browser /usr/share/nginx/html

# # Expose port 80
EXPOSE 80

# # Start the server
CMD ["nginx", "-g", "daemon off;"]