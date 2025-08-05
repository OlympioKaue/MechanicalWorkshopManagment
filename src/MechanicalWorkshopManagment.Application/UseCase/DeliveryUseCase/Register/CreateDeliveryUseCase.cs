using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;

namespace MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.Register
{
    public class CreateDeliveryUseCase : ICreateDeliveryUseCase
    {
        private readonly IViaCep _cep;
        private readonly ISaveChangesWorks _save;
        private readonly IBuys _buy;
        private readonly IDelivery _delivery;
        private readonly ICustomer _customer;


        public CreateDeliveryUseCase(
          IViaCep cep
        , ISaveChangesWorks save 
        , IBuys buy
        , IDelivery delivery
        , ICustomer customer)
        {
            _cep = cep;
            _save = save;
            _buy = buy;
            _delivery = delivery;
            _customer = customer;
        }
        public async Task<ResponseDeliveryCreate> RegistrationDeliveryExecute(int idCustomer)
        {
            //Existe o cliente no banco de dados. ?
            var customerId = await _customer.GetCustomerByFirstOrDefaultID(idCustomer);
            if (customerId is null)
                //Exceção 404.
                throw new NotFoundException("Cliente não encontrado.");
            

            //Busque as compras com status de entrega em espera.
            var getBuysCustomerInWaiting = await _buy.GetPartsBudgetByBuyCustomer(customerId.Id);
            if (getBuysCustomerInWaiting is null || !getBuysCustomerInWaiting.Any())
                //Exceção 404.
                throw new NotFoundException("Não existe compras vinculadas ao id fornecido.");


            //Loop para percorrer e alterar as entregas como Finalizada.
            foreach (var buy in getBuysCustomerInWaiting)
            {
                if (buy.StatusDelivered == DeliveredStatus.InWaiting)
                    buy.StatusDelivered = DeliveredStatus.Finished;
                
            }


            //Existe uma entrega com esse id?
            var existsDelivery = await _delivery.GetDeliveryByBudgetId(idCustomer);

            //Se existir.
            if (existsDelivery != null)
            {
                //Adicione a quantidade de entregas para esse cliente.
                existsDelivery.QuantityDelivered += 1;

                //Salve no banco.
                await _save.SaveChangesAsync();

                //Retorne a resposta que ja existe, e salve.
                return new ResponseDeliveryCreate
                {
                    //Retorno da messagem.
                    Message = "Já existe uma entrega vinculada ao ID, atualizando o número de entregas.",

                    //Cep do cliente.
                    Cep = existsDelivery.CepClient,

                    //Logradouro do cliente.
                    Logradouro = existsDelivery.AddressClient
                };
            }

            //Verifique se há erro na inclusão do Customer.Cep
            if (string.IsNullOrWhiteSpace(customerId.CepClient))
                //Exceção 400.
                throw new OnExceptionSystem($"CEP do cliente está vazio ou inválido.");

            //Integra com API Externa e envia os dados do endereço do cliente.
            var getByCep = await _cep.GetAddressCepAsync(customerId.CepClient);

            //Se não existe ou invalido envie os erros.
            if (getByCep is null)
                //Exceção 404.
                throw new NotFoundException($"CEP '{customerId.CepClient}' inválido ou não encontrado.");




            //Add a entrega no banco.
            var newDelivery = new Delivery
            {
                CustomerId = idCustomer, // id do cliente.
                CepClient = getByCep.Cep, // cep do cliente.
                AddressClient = getByCep.Logradouro, // logradouro do cliente.
                QuantityDelivered = +1, // adicione as vezes que o mesmo cliente aparece na entrega.

            };


            //Adicione no banco o delivery.
            await _delivery.AddDeliveryAsync(newDelivery);


            //Salve as alterações.
            await _save.SaveChangesAsync();


            //Retorne as reposta para o usuário.
            return new ResponseDeliveryCreate
            {
                Message = "Entrega registrada com sucesso.", // mensagem para o cliente.
                Cep = getByCep.Cep, // cep do cliente.
                Logradouro = getByCep.Logradouro, // logradouro do cliente.
                Bairro = getByCep.Bairro, // bairro do cliente.
                Localidade = getByCep.Localidade, // localidade do cliente.
                Uf = getByCep.Uf // uf do cliente.

            };


        }
    }
}
