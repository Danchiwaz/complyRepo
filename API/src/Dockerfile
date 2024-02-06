FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the .csproj and restore any dependencies (via dotnet restore)
COPY API/src/*.csproj ./
RUN dotnet restore

# Copy the main source code
COPY API/src/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 5000

# Start the application
ENTRYPOINT ["dotnet", "API.dll"]
