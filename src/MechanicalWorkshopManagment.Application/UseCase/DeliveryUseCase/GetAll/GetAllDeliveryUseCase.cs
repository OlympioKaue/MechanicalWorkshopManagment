using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;

namespace MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.GetAll
{
    public class GetAllDeliveryUseCase : IGetAllDeliveryUseCase
    {
        private readonly IDelivery _delivery;

        public GetAllDeliveryUseCase(IDelivery delivery)
        {
            _delivery = delivery;
        }

        public async Task<ResponseDeliveryList> GetAllDelivery()
        {
            //Existe entregas no banco. ?
            var thisDeliveryExists = await _delivery.GetDelivery();
            if (thisDeliveryExists is null || thisDeliveryExists.Count is 0)
                //Exceção 404.
                throw new NotFoundException("Entregas não encontrada.");

            //List para armazena a respostas.
            var deliveryList = new List<ResponseDeliveryAll>();

            //Loop para percorrer e armazena na lista.
            foreach(var deliveryItem in thisDeliveryExists)
            {
                var addResponse = new ResponseDeliveryAll
                {
                    ClientName = deliveryItem.Customer.ClientName, // nome do cliente.
                    QuantityDelivered = deliveryItem.QuantityDelivered, // quantidade de entregas.
                };

                //Adicione a lista.
                deliveryList.Add(addResponse);
            }

            //Retorne ao usuário.
            return new ResponseDeliveryList
            {
                Deliverys = deliveryList
            };
        }
    }
}
