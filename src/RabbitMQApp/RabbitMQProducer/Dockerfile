#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RabbitMQProducer/RabbitMQProducer.csproj", "RabbitMQProducer/"]
RUN dotnet restore "RabbitMQProducer/RabbitMQProducer.csproj"
COPY . .
WORKDIR "/src/RabbitMQProducer"
RUN dotnet build "RabbitMQProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMQProducer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQProducer.dll"]