using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetSelected
{
    public class GetSelectedBuyUseCase : IGetSelectedBuyUseCase
    {
        private readonly IBuys _buy;

        public GetSelectedBuyUseCase(IBuys buy)
        {
            _buy = buy;
        }

        public async Task<List<ResponseSelectedBuy>> GetSelectedBuyExecute(int idCustomer)
        {
            //Busque as compras finalizadas no banco, elas existem ?.
            var getBuyAll = await _buy.GetBuys();
            if (!getBuyAll.Any())
                //Exceção 404.
                throw new NotFoundException("Nenhuma compra encontrada com este ID.");

            //Filtre as compras vinculada ao id fornecido e devolta em uma lista.
            var getSelected = getBuyAll.Where(b => b.CustomerId == idCustomer).ToList();
            if (getSelected is null || getSelected.Count is 0)
                //Exceção 404.
                throw new NotFoundException("Não existe compras vinculada a este id, ou não existe compras finalizadas.");

            //List para percorrer as compras feita pelo cliente.
            var customerPurchases = new List<ResponseSelectedBuy>();

            //Loop para percorrer e adicionar as respostas para o usuário.
            foreach (var selectedPurchases in getSelected)
            {
                var addPurchases = new ResponseSelectedBuy
                {
                    Id = selectedPurchases.Id, // id da compra.
                    ClientName = selectedPurchases.Customer.ClientName, // nome do cliente.
                    DatePurchase = selectedPurchases.Date, // data da compra.

                    //List de itens que o cliente comprou.
                    PurchasedItems = new List<ResponseSelectedBuyModification>
                    {
                       //Modifica a resposta retornando o (nome da peça, quantidade da peça e desconto).
                       new ResponseSelectedBuyModification
                       {
                           PartsName = selectedPurchases.Parts.Name, // nome da peça.
                           QuantityParts = selectedPurchases.Quantity, // quantidade de peças.
                           DiscountApplied = (selectedPurchases.Quantity >= 3) ? 0.10m : 0, // desconto aplicado nas peças.
                          
                       }
                    }

                };

                //Adicione na lista.
                customerPurchases.Add(addPurchases);

            }

            //Retorne em lista todas as compras feitas por esse cliente.
            return customerPurchases;
        }

       

        
    }
}
