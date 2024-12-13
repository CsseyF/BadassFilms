FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY BadassFilms.sln ./
COPY BadassFilms.API/BadassFilms.API.csproj BadassFilms.API/
COPY BadassFilms.Core/BadassFilms.Core.csproj BadassFilms.Core/
COPY BadassFilms.Persistence/BadassFilms.Persistence.csproj BadassFilms.Persistence/

WORKDIR /app/BadassFilms.API
RUN dotnet restore

WORKDIR /app
COPY . .

WORKDIR /app/BadassFilms.API
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "BadassFilms.API.dll"]