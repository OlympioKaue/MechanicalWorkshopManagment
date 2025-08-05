ROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar o arquivo da solução
COPY *.sln ./

# Copiar só os arquivos .csproj mantendo a estrutura src/ (exatamente igual ao do projeto)
COPY src/ src/

# Restaura os pacotes, dotnet irá procurar os projetos no caminho correto
RUN dotnet restore MechanicalWorkshopManagment.sln

# Copiar todo o restante do código (src + outros arquivos se existirem)
COPY src/ src/

WORKDIR /app/src/MechanicalWorkshopManagment.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/src/MechanicalWorkshopManagment.API/out ./

ENTRYPOINT ["dotnet", "MechanicalWorkshopManagment.API.dll"]