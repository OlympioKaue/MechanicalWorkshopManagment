using MechanicalWorkshopManagment.Application.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsExcel
{
    //Interface para regra de negócio.
    public interface IGetStockExcelUseCase : IGenericUseCase
    {
        Task<byte[]> GetStockExcelExecute(DateOnly date);
    }
}
