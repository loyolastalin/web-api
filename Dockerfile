# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["OpentelemetryApi/OpentelemetryApi.csproj", "OpentelemetryApi/"]
RUN dotnet restore "OpentelemetryApi/OpentelemetryApi.csproj"

# Copy the remaining source code and build the application
COPY . .
WORKDIR "/src/OpentelemetryApi"
RUN dotnet publish -c Release -o /app/publish

# Use a minimal .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/publish .

# Expose the port the application runs on
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "OpentelemetryApi.dll"]