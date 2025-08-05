using Bogus;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RequestFakes
{
    /// <summary>
    /// Requisição fake para validar.
    /// </summary>
    public class RequestCustomer
    {
        public static RequestCustomerDTO Builder()
        {
            var faker = new Faker();
            return new Faker<RequestCustomerDTO>()
                .RuleFor(src => src.ClientName, faker => faker.Name.FullName())
                .RuleFor(src => src.VehiclePlate, faker => faker.Vehicle.Vin())
                .RuleFor(src => src.CepClient, faker => faker.Random.String(1, 8));
             
                
            
                
            
        }
    }
}
