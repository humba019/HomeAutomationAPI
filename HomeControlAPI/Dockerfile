#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["HomeControlAPI/HomeControlAPI.csproj", "HomeControlAPI/"]
RUN dotnet restore "HomeControlAPI/HomeControlAPI.csproj"
COPY . .
WORKDIR "/src/HomeControlAPI"
RUN dotnet build "HomeControlAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeControlAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeControlAPI.dll"]