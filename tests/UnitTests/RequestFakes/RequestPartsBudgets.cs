using Bogus;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
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
    public class RequestPartsBudgets
    {
        public static RequestPartBudgetDTO Builder()
        {
            var faker = new Faker();
            return new Faker<RequestPartBudgetDTO>()
                .RuleFor(src => src.PartsId, faker => faker.Random.Number(1, 20))
                .RuleFor(src => src.Quantity, faker => faker.Random.Int(1, 20));
        }
    }
}
