using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Delete
{
    public class DeletePartsBudgetUseCase : IDeletePartsBudgetUseCase
    {
        private readonly ICustomer _customer;
        private readonly IPartsBudgets _partsBudget;
        private readonly ISaveChangesWorks _save;

        public DeletePartsBudgetUseCase(ICustomer customer, IPartsBudgets partsBudget, ISaveChangesWorks save)
        {
            _customer = customer;
            _partsBudget = partsBudget;
            _save = save;
        }
        public async Task DeletePartsBudgetExecute(int idCustomer)
        {
            // Busque se existe um cliente com esse id.
            var customerExists = await _customer.GetCustomerByFirstOrDefaultID(idCustomer); 
            if (customerExists == null)
                //Exceção 404.  
                throw new NotFoundException($"Cliente com o Id:({idCustomer}) não encontrado.");

            // Filtre apenas o orçamentoPeça em espera.
            var partsBudgetDelete = customerExists.PartsBudget
                .Where(p => p.BudgetStatus == PartsBudgetStatus.InWaiting)
                .ToList(); 

            //Se não houver orçamentoPeça em espera, lançe o erro.
            if (!partsBudgetDelete.Any())
                //Exceção 404.
                throw new NotFoundException("Não existe orçamentoPeça em espera.");


            //Loop para deletar.
            foreach (var partBudget in partsBudgetDelete)
            {
                _partsBudget.DeletePartsBudget(partBudget);
            }

            // Salva as alterações no banco de dados.
            await _save.SaveChangesAsync(); 

        }
    }
}
