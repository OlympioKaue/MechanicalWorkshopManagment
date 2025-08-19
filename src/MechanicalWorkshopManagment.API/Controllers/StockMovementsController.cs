using MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsExcel;
using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MechanicalWorkshopManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementsController : ControllerBase
    {
        /// <summary>
        /// Retorne uma lista de movimentação no estoque (Entradas).
        /// </summary>
        /// <param name="date">Via Request (DateOnly)</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns></returns>
        [HttpGet("GetStockExcel")]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStockExcel
        ([FromHeader(Name = "data")] DateOnly date, [FromServices] IGetStockExcelUseCase useCase)

        {
            byte[] fileResult = await useCase.GetStockExcelExecute(date);

            if (fileResult.Length > 0)
                return File(fileResult, MediaTypeNames.Application.Octet, "report.xlsx");


            return NoContent();
        }

    }
}
