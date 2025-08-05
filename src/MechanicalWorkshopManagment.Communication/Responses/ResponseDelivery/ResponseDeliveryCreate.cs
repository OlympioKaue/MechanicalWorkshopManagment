using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery
{
    /// <summary>
    /// Retorno da criação de entrega.
    /// </summary>
    public class ResponseDeliveryCreate
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public string? Message { get; set; } // MENSAGEM PARA O USUÁRIO.
        public string? Cep { get; set; } // CEP DO CLIENTE.
        public string? Logradouro { get; set; } // ENDEREÇO.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Bairro { get; set; } // BAIIRO.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Localidade { get; set; } // LOCALIDADE.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Uf { get; set; } // SSP ?.
    

    }
}
