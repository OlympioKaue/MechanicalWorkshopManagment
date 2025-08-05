using Mapster;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.Mapster
{
    /// <summary>
    /// Classe de mapeamento Customer.
    /// </summary>
    public class CustomerMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //POST / PUT(ID)
            config.NewConfig<RequestCustomerDTO, Customer>(); // REQUEST -> ENTITY
            config.NewConfig<Customer, ResponseCustomerCreate>(); // ENTITY -> RESPONSE


            //GET
            config.NewConfig<Customer, ResponseCustomerCreate>(); // ENTITY -> RESPONSE
            config.NewConfig<Customer, ResponseSelectedCustomer>(); // ENTITY -> RESPONSE



        }
    }
}
