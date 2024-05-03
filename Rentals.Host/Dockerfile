#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rentals.Host/Rentals.Host.csproj", "Rentals.Host/"]
RUN dotnet restore "./Rentals.Host/Rentals.Host.csproj"

COPY ["Rentals.Domain/Rentals.Domain.csproj", "Rentals.Domain/"]
RUN dotnet restore "./Rentals.Domain/Rentals.Domain.csproj"

COPY ["Rentals.Core/Rentals.Core.csproj", "Rentals.Core/"]
RUN dotnet restore "./Rentals.Core/Rentals.Core.csproj"

COPY ["Rentals.Application.Core/Rentals.Application.Core.csproj", "Rentals.Application.Core/"]
RUN dotnet restore "./Rentals.Application.Core/Rentals.Application.Core.csproj"

COPY ["Rentals.Infrastructure/Rentals.Infrastructure.csproj", "Rentals.Infrastructure/"]
RUN dotnet restore "./Rentals.Infrastructure/Rentals.Infrastructure.csproj"

COPY ["Rentals.Infrastructure.Abstractions/Rentals.Infrastructure.Abstractions.csproj", "Rentals.Infrastructure.Abstractions/"]
RUN dotnet restore "./Rentals.Infrastructure.Abstractions/Rentals.Infrastructure.Abstractions.csproj"

COPY . .
WORKDIR "/src/Rentals.Host"
RUN dotnet build "./Rentals.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rentals.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rentals.Host.dll"]