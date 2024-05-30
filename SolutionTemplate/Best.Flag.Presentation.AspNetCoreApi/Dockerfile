#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Best.Flag.Presentation.AspNetCoreApi/Best.Flag.Presentation.AspNetCoreApi.csproj", "Best.Flag.Presentation.AspNetCoreApi/"]
RUN dotnet restore "./Best.Flag.Presentation.AspNetCoreApi/Best.Flag.Presentation.AspNetCoreApi.csproj"
COPY . .
WORKDIR "/src/Best.Flag.Presentation.AspNetCoreApi"
RUN dotnet build "./Best.Flag.Presentation.AspNetCoreApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Best.Flag.Presentation.AspNetCoreApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Best.Flag.Presentation.AspNetCoreApi.dll"]