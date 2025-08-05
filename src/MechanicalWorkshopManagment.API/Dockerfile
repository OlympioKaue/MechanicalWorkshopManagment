# Etapa 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln ./
COPY ./MechanicalWorkshopManagment.API/*.csproj ./MechanicalWorkshopManagment.API/
COPY ./MechanicalWorkshopManagment.Application/*.csproj ./MechanicalWorkshopManagment.Application/
COPY ./MechanicalWorkshopManagment.Domain/*.csproj ./MechanicalWorkshopManagment.Domain/
COPY ./MechanicalWorkshopManagment.Infrastructure/*.csproj ./MechanicalWorkshopManagment.Infrastructure/

RUN dotnet restore

COPY . .
WORKDIR /app/MechanicalWorkshopManagment.API
RUN dotnet publish -c Release -o out

# Etapa 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/MechanicalWorkshopManagment.API/out ./
ENTRYPOINT ["dotnet", "MechanicalWorkshopManagment.API.dll"]