using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Validator;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.RequestFakes;

namespace TestWorkshopProject.Customers
{
    /// <summary>
    /// Classe de teste unitários.
    /// </summary>

    public class CustomersTestUnit
    {
        //Requisição com sucesso.
        [Fact]
        public void Sucess()
        {
            var validator = GetValidator();
            var builder = RequestCustomer.Builder();
            builder.CepClient = "08042117";
            builder.VehiclePlate = "LGA5598";


            var result = validator.Validate(builder);

            //Aguarda o retorno true (sem erros).
            result.IsValid.ShouldBeTrue();

        }

        [Fact]
        public void Request_NameClient_CepClient_VehicleClient_Errors()
        {
            var validator = GetValidator();
            var builder = GetBuilder();
            builder.ClientName = null;
            builder.CepClient = "036559816";
            builder.VehiclePlate = "LOOP12345";

            var result = validator.Validate(builder);

            //Aguarda o retorno false (com erros).
            result.IsValid.ShouldBeFalse();

        }



        //Método auxiliar, instacia as validações.
        private ValidatorCustomerUseCase GetValidator()
        {
            return new ValidatorCustomerUseCase();
        }

        //Método auxiliar, instancia a requisição faker.
        private RequestCustomerDTO GetBuilder()
        {
            return new RequestCustomerDTO();
        }

    }
}
