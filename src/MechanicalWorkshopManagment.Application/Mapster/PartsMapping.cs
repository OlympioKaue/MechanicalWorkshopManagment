using Mapster;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.Mapster
{
    /// <summary>
    /// Classe de mapeamento Peças.
    /// </summary>
    public class PartsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
           // POST / UPDATE(ID)
            config.NewConfig<RequestPartDTO, Parts>(); //REQUEST => ENTIDADE
            config.NewConfig<Parts, ResponsePartsCreate>(); // ENTIDADE => RESPONSE


            // GET 
            config.NewConfig<Parts, ResponsePartsGetAll>(); // ENTIDADE => RESPONSE
            config.NewConfig<Parts, ResponsePartsGetSelected>(); // ENTIDADE => RESPONSE



        }
    }
}
