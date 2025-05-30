# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Catalog/Presentation/Catalog.Api/Catalog.Api.csproj", "Catalog/Presentation/Catalog.Api/"]
COPY ["Shared/BuildingBlocks/BuildingBlocks.csproj", "Shared/BuildingBlocks/"]
COPY ["Catalog/Core/Catalog.Application/Catalog.Application.csproj", "Catalog/Core/Catalog.Application/"]
COPY ["Catalog/Core/Catalog.Entities/Catalog.Entities.csproj", "Catalog/Core/Catalog.Entities/"]
COPY ["Catalog/Infrastructure/Catalog.Infrastructure/Catalog.Infrastructure.csproj", "Catalog/Infrastructure/Catalog.Infrastructure/"]
RUN dotnet restore "./Catalog/Presentation/Catalog.Api/Catalog.Api.csproj"
COPY . .
WORKDIR "/src/Catalog/Presentation/Catalog.Api"
RUN dotnet build "./Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]