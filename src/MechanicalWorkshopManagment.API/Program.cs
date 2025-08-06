using Mapster;
using MechanicalWorkshopManagment.API.FilterException;
using MechanicalWorkshopManagment.Application.DependencyExtension;
using MechanicalWorkshopManagment.Application.Mapster;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Infrastructure.DependencyExtension;
using MechanicalWorkshopManagment.Infrastructure.ExtensionRepositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Reconheça a classe controllers.
builder.Services.AddControllers();

//Reconheça os endpoints.
builder.Services.AddEndpointsApiExplorer();

//reconheça o Swagger.
builder.Services.AddSwaggerGen(); 

//Reconheça a classe de extensão.
builder.Services.AddInfrastructure(builder.Configuration);

//Reconheça a classe de extensão, (Reflection).
builder.Services.AddExtensionInjection();

//Reconheça a API Externa para buscar CEP.
builder.Services.AddHttpClient<ViaCepRepository>();

//Converta os valores enum para string na serialização JSON.
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
});


//Reconheça o assembly (ExceptionGerenicFilter), classe de filtrar os erros.
builder.Services.AddMvc(add => add.Filters.Add(typeof(ExcetionGenericFilter)));
TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);


//Valores padrões do C#.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

 app.MapControllers();

app.Run();
