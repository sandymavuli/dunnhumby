# Use the official .NET 8 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file(s) and restore dependencies
COPY ["Dunnhumby.Products.csproj", "./"]
RUN dotnet restore

# Copy the rest of the application source code
COPY . .

# Build the application
RUN dotnet publish -c Release -o /app --no-restore

# Use the official .NET 8 runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app .

# Expose the port the application runs on
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "Dunnhumby.Products.dll"]