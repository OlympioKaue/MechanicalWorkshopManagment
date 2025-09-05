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
        /// <param name="date"> Parâmetro via request (dateOnly)</param>
        /// <param name="useCase">DI para regra de negócio</param>
        /// <returns>Retorne o arquivo em excel</returns>
        [HttpGet("GetStockExcel")]
        [ProducesResponseType(typeof(GenericResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStockExcel
        ([FromHeader(Name = "data")] DateOnly date, [FromServices] IGetStockExcelUseCase useCase)

        {
            byte[] fileResult = await useCase.GetStockExcelExecute(date);

            return File(fileResult, MediaTypeNames.Application.Octet, "report.xlsx");


        }

        [HttpGet("GetStockPDF")]
        public async Task<IActionResult> GetStockPDF(DateOnly date)
        {
            return Ok();
        }

    }
}
