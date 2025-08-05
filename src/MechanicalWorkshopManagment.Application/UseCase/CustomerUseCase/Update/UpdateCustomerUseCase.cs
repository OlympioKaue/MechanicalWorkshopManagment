using Mapster;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Update
{
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomer _customer;
        private readonly ISaveChangesWorks _save;

        public UpdateCustomerUseCase(ICustomer customer, ISaveChangesWorks save)
        {
            _customer = customer;
            _save = save;
        }

        public async Task UpdateCustomerExecute(int idCustomer, RequestCustomerDTO updateCustomer)
        {
            // Valida os dados da request.
            Validate(updateCustomer);

            // Verifica se o cliente existe com o ID informado.
            var thisCustomerExists = await _customer.GetCustomerByFirstOrDefaultID(idCustomer);
            if (thisCustomerExists is null)
                // Exceção 404.
                throw new NotFoundException($"Cliente com Id:({idCustomer}), não encontrado.");

            // Verifica se o cliente já existe com o nome e CEP informados.
            var customerExistsNameIsCep = await _customer.ThisCustomerNameExists(updateCustomer.ClientName!);
            if (customerExistsNameIsCep == true)
                // Exceção 409.
                throw new ExceptionConflict("Já existe um cliente cadastrado com o mesmo nome informado.");



            // Mapeia os dados da request para a entidade Customer.
            var updateCustomerMapping = updateCustomer.Adapt(thisCustomerExists);


            // Atualiza o cliente no sistema, não precisa retornar nada.
            _customer.UpdateCustomer(updateCustomerMapping);


            // Salva as alterações no banco de dados.
            await _save.SaveChangesAsync();


        }

        /// <summary>
        /// Valida os dados do cliente que serão atualizados.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <exception cref="OnExceptionSystem"></exception>
        private void Validate(RequestCustomerDTO updateCustomer)
        {
            //Instancie o validate.
            var validator = new ValidatorCustomerUseCase();

            //Valide os dados.
            var result = validator.Validate(updateCustomer);

            //Se conter erros.
            if (result.IsValid is false)
            {
                // Agrupa os erros de validação em uma lista.
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                // Lança a exceção.
                throw new OnExceptionSystem(errors);
            }
        }
    }
}
