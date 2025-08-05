using Mapster;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetSelected
{
    public class GetSelectedCustomerUseCase : IGetSelectedCustomerUseCase
    {

        private readonly ICustomer _customer;
        public GetSelectedCustomerUseCase(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<ResponseSelectedCustomer> GetSelectedCustomerExecute(int idCustomer)
        {
            // Busca o cliente pelo ID fornecido.
            var getSelectedCustomerExists = await _customer.GetCustomerByFirstOrDefaultID(idCustomer); 
            if (getSelectedCustomerExists is null)
                // Exceção 404.
              throw new NotFoundException($"Cliente com Id:({idCustomer}) não encontrado no sistema.");

            // Retorne para o usuário os dados do cliente selecionado.
            return getSelectedCustomerExists.Adapt<ResponseSelectedCustomer>(); 


        }
    }
}
