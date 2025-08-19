using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsExcel
{
    public class GetStockExcelUseCase : IGetStockExcelUseCase
    {
        private readonly IStockMovements _stock;
        public GetStockExcelUseCase(IStockMovements stock)
        {
            _stock = stock;
        }

        public async Task<byte[]> GetStockExcelExecute(DateOnly date)
        {

            var messageErrors = new List<string>();

            //Inicia-se com o (paramêtro.Year/paramêtro.Month/1).
            var dateIn = new DateTime(year: date.Year, month: date.Month, day: 1);

            //Retorne quantos dias há no mês solicitado.
            var daysInTheMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);

            //Preencha com (paramêtro.Year/paramêtro.Month/QuantosDiasHáNoMês) seguido pela hora, minuto e segundos.
            var dateInEnd = new DateTime(year: date.Year, month: date.Month, day: daysInTheMonth,
                                         hour: 23, minute: 59, second: 59);



            //Busque a movimentação do estoque no mês/ano solicitado.
            var stockMovementsDate = await _stock.GetByStockMovements(dateIn, dateInEnd);
            if (stockMovementsDate.Count is 0)
            {
                messageErrors.Add($"Não existe movimentação no estoque no Mês/Ano:{date.Month}/{date.Year}");

                if (messageErrors.Count > 0)
                {
                    //Junte as mensagens de erro em uma única string.
                    var errorMessage = string.Join("|", messageErrors);
                    // Exceção 404.
                    throw new NotFoundException(errorMessage);
                }
            }


            //Filtre os movimentos de entrada.
            var entry = stockMovementsDate.Where
            (filter => filter.Movements is Communication.Enums.MovementsStatus.Entry)
            .ToList();


            //Filtre os movimentos de saída.
            var exit = stockMovementsDate.Where
            (filter => filter.Movements == Communication.Enums.MovementsStatus.Exit)
            .ToList();


            //Instaciando e criando a tabela no excel, a utilização do using para não bloquear recursos.
            // Com o using o escopo é fechado automaticamente após o uso, liberando os recursos utilizados.
            using var woorkBook = new XLWorkbook();


            //Definindo o nome do excel.
            woorkBook.Author = "Oficina Mecânica 3 Irmãos";


            //Definindo o tamanho da fonte.
            woorkBook.Style.Font.FontSize = 12;


            //Definindo o nome da pagina do excel.
            var woorkSheetEntry = woorkBook.Worksheets.Add("Entradas");
            var woorkSheetExit = woorkBook.Worksheets.Add("Saídas");


            //Entre na função para adicionar dados a coluna do excel.
            InsertHeader(woorkSheetEntry);
            ExitHeader(woorkSheetExit);




            //Se coter entradas.
            if (entry.Count > 0)
            {
                //Incrementando a tabela a coluna.
                var row = 2;

                //Loop
                foreach (var addStock in entry)
                {
                    woorkSheetEntry.Cell($"A{row}").Value = addStock.Parts.Name;
                    woorkSheetEntry.Cell($"B{row}").Value = addStock.Quantity;
                    woorkSheetEntry.Cell($"C{row}").Value = addStock.Date.ToUniversalTime();

                    row++;

                }
            }

            if (entry.Count is 0)
            {
                //Incrementando a tabela a coluna.
                var row = 2;

                woorkSheetEntry.Cell($"A{row}").Value = "Não existe movimentação de entrada no estoque.";
                woorkSheetEntry.Cell($"B{row}").Value = "-";
                woorkSheetEntry.Cell($"C{row}").Value = "-";

                row++;


            }



            //Se conter saídas.
            if (exit.Count > 0)
            {
                //Incrementando a tabela a coluna.
                var row = 2;
                //Loop
                foreach (var addStock in exit)
                {
                    woorkSheetExit.Cell($"A{row}").Value = addStock.Parts.Name;
                    woorkSheetExit.Cell($"B{row}").Value = addStock.Quantity;
                    woorkSheetExit.Cell($"B{row}").Style.NumberFormat.Format = "- #,##0"; // Formatado para exibir o negativo.
                    woorkSheetExit.Cell($"C{row}").Value = addStock.Date.ToUniversalTime();

                    row++;

                }
            }

            if (exit.Count is 0)
            {

                var row = 2;


                woorkSheetExit.Cell($"A{row}").Value = "Não existe movimentação de saída no estoque.";
                woorkSheetExit.Cell($"B{row}").Value = "-";
                woorkSheetExit.Cell($"B{row}").Value = "-";
                woorkSheetExit.Cell($"C{row}").Value = "-";



            }



            //Adicione a memoria.
            var file = new MemoryStream();

            //Salve o arquivo excel.
            woorkBook.SaveAs(file);



            //Retorne o arquivo excel.
            return file.ToArray();
        }




        private void InsertHeader(IXLWorksheet xL)
        {
            //Coluna A1, B1 e C1.
            xL.Cell("A1").Value = "Nome da peça"; // Nome da coluna A1.
            xL.Cell("B1").Value = "Quantidade"; // Nome da coluna B1.
            xL.Cell("C1").Value = "Data da entrada"; // Nome da coluna C1.

            //Texto negrito na colna A1, B1 e C1.
            xL.Cells("A1:C1").Style.Font.Bold = true;

            //Cor de fundo da coluna A1, B1 e C1.
            xL.Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.Green;

            //Alinhamento do texto na coluna A1, B1 e C1.
            xL.Cells("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); // centro A1.
            xL.Cells("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);  // direita B1.
            xL.Cells("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); // centro C1.

        }

        private void ExitHeader(IXLWorksheet xL)
        {
            //Coluna A1, B1 e C1.
            xL.Cell("A1").Value = "Nome da peça"; // Nome da coluna A1.
            xL.Cell("B1").Value = "Quantidade"; // Nome da coluna B1.
            xL.Cell("C1").Value = "Data de saida"; // Nome da coluna C1.


            //Texto negrito na colna A1, B1 e C1.
            xL.Cells("A1:C1").Style.Font.Bold = true;

            //Cor de fundo da coluna A1, B1 e C1.
            xL.Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.Red;

            //Alinhamento do texto na coluna A1, B1 e C1.
            xL.Cells("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); // centro A1.
            xL.Cells("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);  // direita B1.
            xL.Cells("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); // centro C1.

        }
    }
}
