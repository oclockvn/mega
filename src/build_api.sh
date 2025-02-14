#!/bin/bash

# Change to src directory
cd "$(dirname "$0")"

# Ensure the certificate directory exists
mkdir -p ~/.aspnet/https

# Generate development certificate if it doesn't exist
dotnet dev-certs https --clean
dotnet dev-certs https -ep ~/.aspnet/https/aspnetapp.pfx -p "your-password"
dotnet dev-certs https --trust

# Build and run using docker-compose
docker-compose up --build -d