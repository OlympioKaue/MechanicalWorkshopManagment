using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Infrastructure.ExtensionRepositories
{
    /// <summary>
    /// Classe que herda interfaces do tipo (ViaCep).
    /// </summary>
    public class ViaCepRepository : IViaCep
    {
        private readonly HttpClient _httpClient;


        public ViaCepRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDeliveryCreate> GetAddressCepAsync(string cepClient)
        {
            //Busca o cep do cliente.
            var result = await _httpClient.GetStringAsync($"https://viacep.com.br/ws/{cepClient}/json/");

            //Evita diferenciação de maiúsculas e minúsculas.
            var address = JsonSerializer.Deserialize<ResponseDeliveryCreate>(result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Se conter erros.
            if (address!.Cep == null)
                //Retorne a regra de negócio para tratar o erro.
                return null!;


            //Retorne para a regra de negócio.
            return address;

        }


    }
}
