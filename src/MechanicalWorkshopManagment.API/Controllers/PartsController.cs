using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Delete;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetAll;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetSelected;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Update;
using MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsExcel;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        /// <summary>
        /// Registrar uma nova peça no sistema.
        /// </summary>
        /// <param name="useCase">DI para Regra de Negócio</param>
        /// <param name="createParts">Request de registro de peças</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePartsCreate), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateParts([FromServices] ICreatePartsUseCase useCase,
            [FromBody] RequestPartDTO createParts)
        {
            var result = await useCase.RegistrationPartsExecute(createParts);
            return Created("", result); // RETORNE UM 201 CREATED.
        }



        /// <summary>
        /// Obter todas as peças cadastradas no sistema.
        /// </summary>
        /// <param name="useCase">DI para Regra de Negócio</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponsePartsGetList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllParts([FromServices] IGetPartsUseCase useCase)
        {
            var result = await useCase.GetPartsAllExecute();
            return Ok(result); // RETORNE UM 200 OK.
        }



        /// <summary>
        /// Obter uma peça específica pelo ID.
        /// </summary>
        /// <param name="idParts">Id da peça</param>
        /// <param name="useCase">DI para Regra de Negócio</param>
        /// <returns></returns>
        [HttpGet("{idParts:int}")]
        [ProducesResponseType(typeof(ResponsePartsGetSelected), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPartsById([FromRoute] int idParts, [FromServices] IGetPartsSelectedUseCase useCase)
        {
            var result = await useCase.GetPartsSelectedExecute(idParts);
            return Ok(result); // RETORNE UM 200 OK.
        }




        /// <summary>
        /// Atualizar uma peça específica pelo ID.
        /// </summary>
        /// <param name="idParts">Id da peça</param>
        /// <param name="requestUpdate">Dados da request</param>
        /// <param name="useCase">DI para Regra de Negócio</param>
        /// <returns></returns>
        [HttpPut("{idParts:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateParts([FromRoute] int idParts, [FromBody] RequestPartDTO updateParts, [FromServices] IUpdatePartsUseCase useCase)
        {
            await useCase.UpdatePartsExecute(updateParts, idParts);
            return NoContent(); // RETORNE UM 204 NOCONTENT.
        }


        /// <summary>
        /// Deleta uma peça específica pelo ID.
        /// </summary>
        /// <param name="idParts">Id da peça</param>
        /// <param name="useCase">DI para Regra de Negócio</param>
        /// <returns></returns>
        [HttpDelete("{idParts:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParts([FromRoute] int idParts, [FromServices] IDeletePartsUseCase useCase)
        {
            await useCase.DeletePartsExecute(idParts);
            return NoContent(); // RETORNE UM 204 NOCONTENT.

        }


        
    }
}
