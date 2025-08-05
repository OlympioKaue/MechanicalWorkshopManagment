using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{

    public interface ICustomer
    {
        /// <summary>
        /// Adiciona o cliente no banco de dados.
        /// </summary>
        /// <param name="createCustomer"></param>
        /// <returns></returns>
        Task AddCustomer(Customer createCustomer);


        /// <summary>
        /// Atualiza as informações de um cliente existente no banco de dados.
        /// </summary>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        void UpdateCustomer(Customer updateCustomer);




        /// <summary>
        /// Retorne uma lista de todos os clientes cadastrados no banco de dados.
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> ThisCustomerExists();



        /// <summary>
        /// Retorna o cliente com o ID fornecido, retorne um booleano.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<bool?> GetCustomerByAnyId(int idCustomer);



        /// <summary>
        /// Retorna o cliente com o ID fornecido, retorne um null se não existir.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<Customer?> GetCustomerByFirstOrDefaultID(int idCustomer);



        /// <summary>
        /// Deleta um cliente do banco de dados.
        /// </summary>
        /// <param name="deleteCustomer"></param>
        void DeleteCustomer(Customer deleteCustomer);


        /// <summary>
        /// Existe o nome do cliente cadastrado no banco ?.
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        Task<bool?> ThisCustomerNameExists(string customerName);
    }


}
