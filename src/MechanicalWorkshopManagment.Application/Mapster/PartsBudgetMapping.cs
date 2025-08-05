using Mapster;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.Mapster
{
    /// <summary>
    /// Classe de mapeamento OrçamentoPeça.
    /// </summary>
    public class PartsBudgetMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //POST / UPDATE(ID)
            config.NewConfig<RequestPartBudgetDTO, PartsBudget>(); // REQUEST -> ENTITY


            //GET
            config.NewConfig<PartsBudget, ResponsePartsBudgetGetAll>() ; // ENTITY -> RESPONSE
            config.NewConfig<PartsBudget, ResponseSelectedPartsBudget>(); // ENTITY -> RESPONSE


        }
    }
}
