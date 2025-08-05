using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RequestFakes;

namespace TestWorkshopProject.Parts
{
    /// <summary>
    /// Classe de teste unitários.
    /// </summary>

    public class PartsTestUnit
    {
        //Requisição com sucesso.
        [Fact]
        public void RequestSucess()
        {
            var validator = GetValidator();
            var builder = RequestParts.Builder();

            var result = validator.Validate(builder);

            //Aguarda o retorno true (sem erros).
            result.IsValid.ShouldBeTrue();

        }

        //Requisição com erros.
        [Fact]
        public void Request_Name_Price_Quantity_Errors()
        {
            var validator = GetValidator();
            var builder = GetBuilder();
            builder.Name = null;
            builder.Price = -1;
            builder.Quantity = -1;


            var result = validator.Validate(builder);

            //Aguardo o retorno false (com erros).
            result.IsValid.ShouldBeFalse();
        }



        //Método auxiliar, instacia as validações.
        private ValidatorPartsUseCase GetValidator()
        {
            return new ValidatorPartsUseCase();
        }

        //Método auxiliar, instancia a requisição faker.
        private RequestPartDTO GetBuilder()
        {
            return new RequestPartDTO();
        }

    }
}
