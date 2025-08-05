using Mapster;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetAll
{
    public class GetAllCustomerUseCase : IGetAllCustomerUseCase
    {
        private readonly ICustomer _customer;

        public GetAllCustomerUseCase(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<ResponseCustomerGetList> GetAllCustomerExecute()
        {
            // Existe clientes cadastrado no banco ?.
            var thiscustomerExists = await _customer.ThisCustomerExists(); 
            if (thiscustomerExists.Count is 0)
                // Exceção 404.
                throw new NotFoundException("Não existe clientes cadastrados no sistema."); 

            //Retorne os dados enviados pela entidade.
            var response = thiscustomerExists.Adapt<List<ResponseCustomerCreate>>();


            // Retorne a lista de clientes para o usuário.
            return new ResponseCustomerGetList
            {
                Customers = response 
            };

        }
    }
}
