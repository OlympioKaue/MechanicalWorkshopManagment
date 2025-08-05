using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IViaCep 
    {
        /// <summary>
        /// Busca o endereço a partir do CEP fornecido usando a API ViaCep.
        /// </summary>
        /// <param name="cepClient"></param>
        /// <returns></returns>
        Task<ResponseDeliveryCreate> GetAddressCepAsync(string cepClient);
    }
}
