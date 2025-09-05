
using MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsPDF.Fonts;
using PdfSharp.Fonts;

namespace MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsPDF;

public class GetStockPdfUseCase : IGetStockPdfUseCase
{
    public GetStockPdfUseCase()
    {
        GlobalFontSettings.FontResolver = new MechanicalWorkshopManagmentReportFontResolver();
    }

    public Task<byte[]> GetStockPdfExecute(DateOnly date)
    {
        
    }
}
