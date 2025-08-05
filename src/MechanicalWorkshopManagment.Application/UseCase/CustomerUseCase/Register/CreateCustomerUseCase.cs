using Mapster;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Register
{
    public class CreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomer _customer;
        private readonly ISaveChangesWorks _save;
        public CreateCustomerUseCase(ICustomer customer, ISaveChangesWorks save)
        {
            _customer = customer;
            _save = save;
        }
        public async Task<ResponseCustomerCreate> RegistrationCustomerExecute(RequestCustomerDTO createCustomer)
        {
            // Valida os dados do cliente.
            Validate(createCustomer);

            // mapeia o DTO para a entidade Customer.
            var customerMapping = createCustomer.Adapt<Customer>(); 

            var thisCustomerNameExists = await _customer.ThisCustomerNameExists(createCustomer.ClientName!);
            if (thisCustomerNameExists is true)
                // Exceção 409.
                throw new ExceptionConflict("Cliente ja está cadastrado no sistema.");

            // Adiciona no banco de dados.
            await _customer.AddCustomer(customerMapping);

            // Salva as alterações no banco de dados.
            await _save.SaveChangesAsync(); 

            //Retorne o mapeamento da entidade.
            var response = customerMapping.Adapt<ResponseCustomerCreate>();

            // Retorna a resposta mapeada para o usuário.
            return response; 
        }

        private void Validate(RequestCustomerDTO createCustomer)
        {
            //Instacie o validator.
            var validator = new ValidatorCustomerUseCase();

            //Valide os dados.
            var result = validator.Validate(createCustomer);

            //Se conter erros.
            if(result.IsValid is false)
            {
                // Agrupa os erros em uma lista de strings
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                // Lança a exceção.
                throw new OnExceptionSystem(errors); 
            }
        }
    }
}
