#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pedidos/Pedidos.csproj", "Pedidos/"]
RUN dotnet restore "Pedidos/Pedidos.csproj"
COPY . .
WORKDIR "/src/Pedidos"
RUN dotnet build "Pedidos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedidos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedidos.dll"]
