using Bogus;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
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
    public class RequestBuy
    {
        public static RequestBuyDTO Builder()
        {
            var faker = new Faker();
            return new Faker<RequestBuyDTO>()
                .RuleFor(src => src.CostPrice, faker => faker.Finance.Amount(100, 1000));
        }
    }
}
