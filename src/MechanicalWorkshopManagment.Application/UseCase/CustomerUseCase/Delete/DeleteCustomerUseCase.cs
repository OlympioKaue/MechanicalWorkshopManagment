using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Delete
{
   
    public class DeleteCustomerUseCase : IDeleteCustomerUseCase
    {
        private readonly ICustomer _customer;
        private readonly ISaveChangesWorks _save;

        public DeleteCustomerUseCase(ICustomer customer, ISaveChangesWorks save)
        {
            _customer = customer;
            _save = save;
        }

        public async Task DeleteCustomerExecute(int idCustomer)
        {
            // Existe um cliente com o id fornecido ?.
            var customerExists = await _customer.GetCustomerByFirstOrDefaultID(idCustomer); 
            if (customerExists is null)
                // Exceção 404.
                throw new NotFoundException($"Cliente com Id:({idCustomer}), não encontrado.");

            // Deleta o cliente do sistema, não precisa retornar nada.
            _customer.DeleteCustomer(customerExists);

            // Salva as alterações no banco de dados.   
            await _save.SaveChangesAsync(); 
        }
    }
}
