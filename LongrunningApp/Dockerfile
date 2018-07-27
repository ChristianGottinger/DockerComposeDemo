FROM microsoft/dotnet:2.0.9-runtime-jessie AS base
WORKDIR /app

FROM microsoft/dotnet:2.0.9-sdk-2.1.202-jessie AS build
WORKDIR /src
COPY LongrunningApp.csproj .
RUN dotnet restore LongrunningApp.csproj
COPY . .
WORKDIR /src
RUN dotnet build LongrunningApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish LongrunningApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LongrunningApp.dll", "redis"]
