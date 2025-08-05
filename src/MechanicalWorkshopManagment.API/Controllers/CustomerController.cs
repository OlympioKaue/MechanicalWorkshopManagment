using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Delete;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetAll;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetSelected;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Update;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using MechanicalWorkshopManagment.Exception.BaseException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Registrar um cliente (Nome e CEP).
        /// </summary>
        /// <param name="createCustomer">Request para envio</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCustomerCreate), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status409Conflict)]

        public async Task<IActionResult> CreateCustomer([FromBody] RequestCustomerDTO createCustomer,
            [FromServices] ICreateCustomerUseCase useCase)
        {
            var result = await useCase.RegistrationCustomerExecute(createCustomer);
            return Created("", result); // RETORNE UM 204.
        }


        /// <summary>
        /// Obter todos os clientes cadastrados no sistema.
        /// </summary>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseCustomerGetList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCustomer([FromServices] IGetAllCustomerUseCase useCase)
        {
            var result = await useCase.GetAllCustomerExecute();

            return Ok(result); // RETORNE UM 200 OK.
        }



        /// <summary>
        /// Obter clientes atrave do ID.
        /// </summary>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpGet("{idCustomer:int}")]
        [ProducesResponseType(typeof(ResponseCustomerGetList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerById([FromServices] IGetSelectedCustomerUseCase useCase, [FromRoute] int idCustomer)
        {
            var result = await useCase.GetSelectedCustomerExecute(idCustomer);
            return Ok(result); //RETORNE UM 200 OK.
        }


        /// <summary>
        /// Atualiza os dados vinculado ao id.
        /// </summary>
        /// <param name="updateCustomer">Request para envio</param>
        /// <param name="idCustomer">Id do cliente</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpPut("{idCustomer:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateCustomer([FromBody] RequestCustomerDTO updateCustomer, [FromRoute] int idCustomer,
          [FromServices] IUpdateCustomerUseCase useCase)
        {
            await useCase.UpdateCustomerExecute(idCustomer, updateCustomer);
            return NoContent(); // RETORNE UM 204 NOCONTENT.

        }



        /// <summary>
        /// Deleta os dados vinculado ao id.
        /// </summary>
        /// <param name="idCustomer">Id do cliente</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpDelete("{idCustomer:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int idCustomer, IDeleteCustomerUseCase useCase)
        {
            await useCase.DeleteCustomerExecute(idCustomer);
            return NoContent(); // RETORNE UM 204 NOCONTENT.
        }
    }
}
