# Use Node.js base image for development
FROM node:lts AS dev

# Set working directory
WORKDIR /app

# Copy package files and install dependencies
COPY package*.json ./ 
RUN npm install

# Copy application files
COPY . .

# Install Angular CLI globally for live development
RUN npm install -g @angular/cli

# Expose the default Angular development port
EXPOSE 4200

# Start the Angular development server
CMD ["ng serve", "--host", "0.0.0.0"]

