using Mapster;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetAll
{
    public class GetAllBuyUseCase : IGetAllBuyUseCase
    {
        private readonly IBuys _buy;

        public GetAllBuyUseCase(IBuys buy)
        {
            _buy = buy;
        }

        public async Task<ResponseBuyList> GetAllBuyExecute()
        {
            //Busque apenas compras finalizadas no banco, elas existem ?.
            var getBuyAll = await _buy.GetBuys();
            if (getBuyAll is null || getBuyAll.Count is 0)
                //Exceção 404.
                throw new NotFoundException("Não existe compras finalizadas no banco de dados.");

            //Seleciona o nome do cliente e a quantidade comprada.
            var getMapping = getBuyAll
                // Evite duplicidade de nomes.
                .GroupBy(x => x.Customer.ClientName) 
                .Select(g => new ResponseGetAllBuy
                {
                    ClientName = g.Key, // nome do cliente.
                    QuantityPurchased = g.Count() // (x) de quantidade compradas.

                }).ToList();

            //Retorne para o usuário.
            return new ResponseBuyList
            {
                Buys = getMapping,
            };

        }
    }
}
