#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SQL.PathBased/SQL.PathBased.csproj", "SQL.PathBased/"]
COPY ["SQL.ClosureTable/SQL.ClosureTable.csproj", "SQL.ClosureTable/"]
COPY ["ElasticStack/ElasticStack.csproj", "ElasticStack/"]
COPY ["MongoDB/MongoDB.csproj", "MongoDB/"]

RUN dotnet restore "MongoDB/MongoDB.csproj"

COPY . .
WORKDIR "/src/MongoDB"
RUN dotnet build "MongoDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN apt-get -y update
RUN apt-get -y install curl

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MongoDB.dll"]