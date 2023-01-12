#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ElasticsearchApi/ElasticsearchApi.csproj", "ElasticsearchApi/"]
RUN dotnet restore "ElasticsearchApi/ElasticsearchApi.csproj"
COPY . .
WORKDIR "/src/ElasticsearchApi"
RUN dotnet build "ElasticsearchApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElasticsearchApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElasticsearchApi.dll"]