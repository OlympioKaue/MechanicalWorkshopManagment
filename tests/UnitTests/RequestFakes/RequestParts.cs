using Bogus;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
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
    public class RequestParts
    {
        public static RequestPartDTO Builder()
        {
            var faker = new Faker();
            return new Faker<RequestPartDTO>()
             .RuleFor(src => src.Name, faker => faker.Name.FullName())
             .RuleFor(src => src.Price, faker => faker.Finance.Amount())
             .RuleFor(src => src.Quantity, faker => faker.Random.Int(2, 100));
        }
    }
}
