# Use the official .NET 8 SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ../BojLeave.sln ./
COPY ./*.csproj ./
COPY ../BojLeave.Application/*.csproj ../BojLeave.Application/
COPY ../BojLeave.Domain/*.csproj ../BojLeave.Domain/
COPY ../BojLeave.Infrastructure/*.csproj ../BojLeave.Infrastructure/
RUN dotnet restore

# Copy everything else and build
COPY .. .
WORKDIR /src
RUN dotnet publish BojLeave.Api/BojLeave.Api.csproj -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "BojLeave.Api.dll"]
