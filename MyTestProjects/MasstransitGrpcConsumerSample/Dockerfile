#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyTestProjects/MasstransitGrpcConsumerSample/MasstransitGrpcConsumerSample.csproj", "MyTestProjects/MasstransitGrpcConsumerSample/"]
COPY ["src/Transports/MassTransit.GrpcTransport/MassTransit.GrpcTransport.csproj", "src/Transports/MassTransit.GrpcTransport/"]
COPY ["src/MassTransit.Newtonsoft/MassTransit.Newtonsoft.csproj", "src/MassTransit.Newtonsoft/"]
COPY ["src/MassTransit/MassTransit.csproj", "src/MassTransit/"]
COPY ["src/MassTransit.Abstractions/MassTransit.Abstractions.csproj", "src/MassTransit.Abstractions/"]
COPY ["MyTestProjects/MessageContracts/MessageContracts.csproj", "MyTestProjects/MessageContracts/"]
RUN dotnet restore "MyTestProjects/MasstransitGrpcConsumerSample/MasstransitGrpcConsumerSample.csproj"
COPY . .
WORKDIR "/src/MyTestProjects/MasstransitGrpcConsumerSample"
RUN dotnet build "MasstransitGrpcConsumerSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasstransitGrpcConsumerSample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasstransitGrpcConsumerSample.dll"]