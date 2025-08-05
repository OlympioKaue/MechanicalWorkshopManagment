using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Validator;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RequestFakes;

namespace TestWorkshopProject.PartsBudget
{
    public class PartsBudgetTestUnit
    {
        //Requisição com sucesso.
        [Fact]
        public void Sucess()
        {
            var validator = GetValidator();
            var builder = RequestPartsBudgets.Builder();

            var requestPartsBudgetList = new RequestPartBudgetListDTO
            {
                partBudget = new List<RequestPartBudgetDTO> { builder }
            };

            var result = validator.Validate(requestPartsBudgetList);

            //Aguarda o retorno true (sem erros).
            result.IsValid.ShouldBeTrue();

        }

        [Fact]
        public void Request_PartsId_Quantity()
        {
            var validator = GetValidator();
            var builder = GetBuilder();
            builder.PartsId = 0;
            builder.Quantity = -1;

            var requestPartsBudgetList = new RequestPartBudgetListDTO
            {
                partBudget = new List<RequestPartBudgetDTO> { builder }
            };

            var result = validator.Validate(requestPartsBudgetList);

            //Aguarda o retorno false (com erros).
            result.IsValid.ShouldBeFalse();

        }



        //Método auxiliar, instacia as validações.
        private ValidatorPartsBudgetUseCase GetValidator()
        {
            return new ValidatorPartsBudgetUseCase();
        }

        //Método auxiliar, instancia a requisição faker.
        private RequestPartBudgetDTO GetBuilder()
        {
            return new RequestPartBudgetDTO();
        }

    }
}
