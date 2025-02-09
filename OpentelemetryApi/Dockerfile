FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files
COPY *.csproj ./
RUN dotnet restore

# Copy remaining source code and build the application
COPY . ./
RUN dotnet publish -c Release -o /out

# Use a minimal .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy built application from previous stage
COPY --from=build /out .

# Set entry point
ENTRYPOINT ["dotnet", "OpentelimetryApi.dll"]