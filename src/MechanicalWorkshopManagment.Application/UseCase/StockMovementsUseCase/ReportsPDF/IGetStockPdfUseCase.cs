using MechanicalWorkshopManagment.Application.Reflection;

namespace MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsPDF;

public interface IGetStockPdfUseCase : IGenericUseCase
{
    Task<byte[]> GetStockPdfExecute(DateOnly date);
}
