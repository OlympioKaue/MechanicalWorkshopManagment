FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY src/ src/
COPY tests/ tests/

RUN dotnet restore MechanicalWorkshopManagment.sln

COPY src/ src/
COPY tests/ tests/

WORKDIR /app/src/MechanicalWorkshopManagment.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/src/MechanicalWorkshopManagment.API/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "MechanicalWorkshopManagment.API.dll"]