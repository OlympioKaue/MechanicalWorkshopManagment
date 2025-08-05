using MechanicalWorkshopManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IPartsBudgets
    {
        /// <summary>
        /// Adicionar um orçamentoPeça no banco.
        /// </summary>
        /// <param name="createPartBudget"></param>
        /// <returns></returns>
        Task AddPartsBudgetAsync(PartsBudget createPartBudget);

         
        /// <summary>
        /// Atualizar dados no banco.
        /// </summary>
        /// <param name="partsBudget"></param>
        /// <returns></returns>
        Task<bool> UpdatePartsBudgetAsync(PartsBudget partsBudget);



        /// <summary>
        /// Retorna uma lista de orçamento.
        /// </summary>
        /// <returns></returns>
        Task<List<PartsBudget>> GetAllPartsBudgetsAsync();



        /// <summary>
        /// Retorna uma lista de orçamento, com o id do cliente.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<List<PartsBudget>> GetSelectedPartsBudget(int idCustomer);



        /// <summary>
        /// Retorna uma lista de orçamento, filtrando apenas pelo id do cliente.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<List<PartsBudget>> GetPartsBudgetWithList(int idCustomer);
        


        /// <summary>
        /// Deleta o orçamentoPeça no banco de dados.
        /// </summary>
        /// <param name="deletePartsBudget"></param>
        void DeletePartsBudget(PartsBudget deletePartsBudget);

        /// <summary>
        /// Deleta o orçamentoPeça em espera, apenas de compras negadas.
        /// </summary>
        /// <param name="deletePartsBudgetPurchaseDenied"></param>
        /// <returns></returns>
        Task DeletePartsBudgetPurchaseDenied(List<PartsBudget> deletePartsBudgetPurchaseDenied);


    }
}
