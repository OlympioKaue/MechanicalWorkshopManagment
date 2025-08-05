using Mapster;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetAll
{
    public class GetAllPartsBudgetsUseCase : IGetAllPartsBudgetsUseCase
    {
        private readonly IPartsBudgets _partsBudget;

        public GetAllPartsBudgetsUseCase(IPartsBudgets partsBudget)
        {
            _partsBudget = partsBudget;
        }

        public async Task<ResponsePartsBudgetList> GetAllPartsBudgetExecute()
        {
            // Existe orçamentoPeças no banco ?.
            var thisPartsBudget = await _partsBudget.GetAllPartsBudgetsAsync();
            if (thisPartsBudget.Count is 0)
                // Exceção 404.
                throw new NotFoundException("Lista de orçamentos não encontrado.");

            //Lista para separar orçamentoPeça de (Em espera / Finalizado), incialmente vazio.
            var listPartsBudget = new List<ResponsePartsBudgetGetAll>();

            //Loop
            foreach (var BudgetPartWaitingOrCompleted in thisPartsBudget)
            {
                //Status do orçamento.
                PartsBudgetStatus status = BudgetPartWaitingOrCompleted.BudgetStatus;

                //Adicione ao response.
                var addListBudgetParts = new ResponsePartsBudgetGetAll()
                {
                    Id = BudgetPartWaitingOrCompleted.Id, // id do orçamento.
                    PartsId = BudgetPartWaitingOrCompleted.PartsId, // id da peça.
                    ClientName = BudgetPartWaitingOrCompleted.Customer.ClientName, // nome do cliente.
                    BudgetStatus = status == PartsBudgetStatus.InWaiting ? PartsBudgetStatus.InWaiting : status, // se for em espera retorne ou retorne finalizado.
                };

                //Adicionando a lista de ResponsePartsBudgetGetAll.
                listPartsBudget.Add(addListBudgetParts);

            }

            // Retorna um lista de orçamentoPeça para o usuário.
            return new ResponsePartsBudgetList
            {

                partsBudget = listPartsBudget
            };
        }
    }
}
