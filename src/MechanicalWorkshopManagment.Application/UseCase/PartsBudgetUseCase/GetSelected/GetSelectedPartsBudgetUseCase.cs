using Mapster;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetSelected
{
    public class GetSelectedPartsBudgetUseCase : IGetSelectedPartsBudgetUseCase
    {
        private readonly IPartsBudgets _partsBudget;


        public GetSelectedPartsBudgetUseCase(IPartsBudgets partsBudget)
        {
            _partsBudget = partsBudget;

        }

        public async Task<ResponseSelectedListPartsBudget> GetSelectedPartsBudgetExecute(int idCustomer)
        {

            //Verifica se existe orçamento vinculados a esse id, e devolta uma lista de deles.
            var partsBudgetMapping = await _partsBudget.GetSelectedPartsBudget(idCustomer);
            if (partsBudgetMapping.Count is 0 || partsBudgetMapping is null)
                //Exceção 404.
                throw new NotFoundException("Não existe orçamentos vinculado a este ID.");

            //Faça o mapemanto da entidade para a resposta.
            var listPartBudgetMapping = partsBudgetMapping.Adapt<List<ResponseSelectedPartsBudget>>();

            // Retorna a resposta para o usuário.
            return new ResponseSelectedListPartsBudget
            {
                PartsBudgetSelected = listPartBudgetMapping,
            };


        }
    }
}
