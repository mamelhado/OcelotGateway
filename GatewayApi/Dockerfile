#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GatewayApi/Gateway.Api.csproj", "GatewayApi/"]
RUN dotnet restore "GatewayApi/Gateway.Api.csproj"
COPY . .
WORKDIR "/src/GatewayApi"
RUN dotnet build "Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]
