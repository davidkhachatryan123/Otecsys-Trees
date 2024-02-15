#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["TreeSQL/TreeSQL.csproj", "TreeSQL/"]
COPY ["TreeElasticStack/TreeElasticStack.csproj", "TreeElasticStack/"]

RUN dotnet restore "TreeSQL/TreeSQL.csproj"

COPY . .
WORKDIR "/src/TreeSQL"
RUN dotnet build "TreeSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TreeSQL.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN apt-get -y update
RUN apt-get -y install curl

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TreeSQL.dll"]