#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CdcApi/CdcApi.csproj", "CdcApi/"]
RUN dotnet restore "CdcApi/CdcApi.csproj"
COPY . .
WORKDIR "/src/CdcApi"
RUN dotnet build "CdcApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CdcApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CdcApi.dll"]