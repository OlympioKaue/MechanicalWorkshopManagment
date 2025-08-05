using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Delete;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetAll;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetSelected;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Register;
using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Update;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using Microsoft.AspNetCore.Mvc;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartBudgetController : ControllerBase
    {

        /// <summary>
        /// Registrar o orçamentoPeça com ID do cliente, (ID PEÇA E QUANTIDADE), A inclusão pode ser feita no formato de List.
        /// </summary>
        /// <param name="idCustomer"> ID do Cliente</param>
        /// <param name="useCase">DI da regra de Negócio</param>
        /// <param name="createPartBudget">Request do dados do cliente com a peça</param>
        /// <returns>Retorne o registro da peça incluindo o ID da peça e do cliente</returns>
        [HttpPost("CreatePartBudget/{idCustomer:int}")]
        [ProducesResponseType(typeof(ResponsePartsBudgetCreate), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePartsBudget([FromRoute] int idCustomer,
            [FromServices] IPartsBudgetUseCase useCase, [FromBody] RequestPartBudgetListDTO createPartBudget)
        {
            var result = await useCase.RegistrationPartsBudgetExecute(createPartBudget, idCustomer);
            return Created("", result); // RETORNE UM 201 CREATED.
        }

        /// <summary>
        /// Obter uma Lista de orçamentoPeça.
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [ProducesResponseType(typeof(ResponsePartsBudgetList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPartsBudget([FromServices] IGetAllPartsBudgetsUseCase useCase)
        {
            var result = await useCase.GetAllPartsBudgetExecute();
            return Ok(result); // RETORNE UM 200 OK.
        }



        /// <summary>
        /// Retorne os dados do orçamentoPeça a partir do Id do cliente.
        /// </summary>
        /// <param name="useCase">DI Para regra de negócio</param>
        /// <param name="idCustomer">Id do Cliente</param>
        /// <returns></returns>
        [HttpGet("{idCustomer}")]
        [ProducesResponseType(typeof(ResponseSelectedListPartsBudget), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSelectedPartsBudget([FromServices] IGetSelectedPartsBudgetUseCase useCase, int idCustomer)
        {
            var result = await useCase.GetSelectedPartsBudgetExecute(idCustomer);
            return Ok(result); // RETORNE UM 200 OK 
        }


        /// <summary>
        /// Atualize o orçamentoPeça Existente no banco de dados.
        /// </summary>
        /// <param name="useCase">DI Para regra de negócio</param>
        /// <param name="updatePartBudget">Dados da Request</param>
        /// <param name="idCustomer">id do Cliente</param>
        /// <returns></returns>
        [HttpPut("{idCustomer}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartsBudget([FromServices] IUpdatePartsBudgetUseCase useCase, [FromBody] RequestPartBudgetListDTO updatePartBudget, 
            [FromRoute] int idCustomer)
        {
            await useCase.UpdatePartsBudgetExecute(updatePartBudget, idCustomer);
            return NoContent(); // RETORNE UM 204 NOCONTENT.
        }


        /// <summary>
        /// Deleta o orçamentoPeça Existente no banco (apenas orçamentos em espera).
        /// </summary>
        /// <param name="useCase">DI Para regra de negócio</param>
        /// <param name="idCustomer">Id do Cliente</param>
        /// <returns></returns>
        [HttpDelete("{idCustomer}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePartsBudget([FromServices] IDeletePartsBudgetUseCase useCase, int idCustomer)
        {
            await useCase.DeletePartsBudgetExecute(idCustomer);
            return NoContent(); // RETORNE UM 204 NOCONTENT.
        }



    }
}
