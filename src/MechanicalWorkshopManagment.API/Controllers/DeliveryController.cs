using MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.GetAll;
using MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.Register;
using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using Microsoft.AspNetCore.Mvc;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        /// <summary>
        /// Registrar uma entrega para um cliente.
        /// </summary>
        /// <param name="idCustomer">Id do cliente</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idCustomer:int}")]
        [ProducesResponseType(typeof(ResponseDeliveryCreate), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateDelivery([FromRoute] int idCustomer,
            [FromServices] ICreateDeliveryUseCase useCase)

        {
            var result = await useCase.RegistrationDeliveryExecute(idCustomer);
            return Created("", result); // RETORNE UM 201 CREATED.
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDeliveryList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDelivery([FromServices] IGetAllDeliveryUseCase useCase)
        {
            var result = await useCase.GetAllDelivery();
            return Ok(result); // RETORNE UM 200 OK.
        }

    }
}


