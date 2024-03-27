#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Events/Events.API.csproj", "src/Events/"]
COPY ["src/Events.Infrastructure/Events.Infrastructure.csproj", "src/Events.Infrastructure/"]
COPY ["src/Events.Application/Events.Application.csproj", "src/Events.Application/"]
COPY ["src/Events.Domain/Events.Domain.csproj", "src/Events.Domain/"]
RUN dotnet restore "./src/Events/./Events.API.csproj"
COPY . .
WORKDIR "/src/src/Events"
RUN dotnet build "./Events.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Events.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Events.API.dll"]