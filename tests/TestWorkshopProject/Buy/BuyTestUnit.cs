using MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Validator;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RequestFakes;

namespace TestWorkshopProject.Buy
{
    public class BuyTestUnit
    {
        //Requisição com sucesso.
        [Fact]
        public void Sucess()
        {
            var validator = GetValidator();
            var builder = RequestBuy.Builder();

            var result = validator.Validate(builder);

            //Aguarda o retorno true (sem erros).
            result.IsValid.ShouldBeTrue();
        }


        [Fact]
        public void Request_CostPrice_Errors()
        {
            var validator = GetValidator();
            var builder = GetBuilder();
            builder.CostPrice = -100;

            var result = validator.Validate(builder);

            //Aguarda o retorno false (com erros).
            result.IsValid.ShouldBeFalse();
        }


        //Método auxiliar, instacia as validações.
        private ValidatorBuyUseCase GetValidator()
        {
            return new ValidatorBuyUseCase();
        }

        //Método auxiliar, instancia a requisição faker.
        private RequestBuyDTO GetBuilder()
        {
            return new RequestBuyDTO();
        }
    }
}
