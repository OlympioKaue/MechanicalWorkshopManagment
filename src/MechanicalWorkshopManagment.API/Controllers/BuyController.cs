using MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetAll;
using MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetSelected;
using MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Register;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using Microsoft.AspNetCore.Mvc;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        /// <summary>
        /// Registrar a compra de peças, com o id do clientes.
        /// </summary>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <param name="createBuy">Dados via request</param>
        /// <param name="idCustomer">Realizar compra com o id do cliente</param>
        /// <returns></returns>
        [HttpPost("{idCustomer:int}")]
        [ProducesResponseType(typeof(ResponseBuyCreate), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBuy(
            [FromServices] ICreateBuyUseCase useCase, 
            [FromBody] RequestBuyDTO createBuy, [FromRoute] int idCustomer)
        {
            var result = await useCase.RegistrationBuyExecute(createBuy, idCustomer);
            return Created("", result); // RETORNE UM 201 CREATED.
        }


        /// <summary>
        /// Obter compras feita pelo cliente.
        /// </summary>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBuyList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBuys([FromServices] IGetAllBuyUseCase useCase)
        {
            var result = await useCase.GetAllBuyExecute();
            return Ok(result); // RETORNE UM 200 OK. 
        }

        /// <summary>
        /// Obter compras feita pelo cliente vinculado ao ID.
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        [HttpGet("{idCustomer:int}")]
        [ProducesResponseType(typeof(ResponseSelectedBuy), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSelectedBuys([FromServices] IGetSelectedBuyUseCase useCase, [FromRoute] int idCustomer)
        {
            var result = await useCase.GetSelectedBuyExecute(idCustomer);
            return Ok(result); // RETORNE UM 200 OK.
        }


    }
}
