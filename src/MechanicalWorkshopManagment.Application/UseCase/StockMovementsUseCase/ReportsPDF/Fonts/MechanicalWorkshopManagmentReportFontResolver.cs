using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;
using System.Reflection;

namespace MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsPDF.Fonts;

public class MechanicalWorkshopManagmentReportFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        //Entre no método ReadFontFile que lê o arquivo de fonte incorporado no assembly.
        var stream = ReadFontFile(faceName);

        //Se null, retorne a fonte padrão.
        stream ??= ReadFontFile(FontHelper.DEFAULT_FONT);

        //Pega o formato e tamanho do arquivo de fonte.
        var formatLength = (int)stream!.Length;

        //Cria um array de bytes para armazenar os dados da fonte.
        var data = new byte[formatLength];

        //Le o array, a partir da posição 0, até o tamanho do arquivo de fonte.
        stream.Read(buffer: data, 0, formatLength);

        //Retorna o array de bytes com os dados da fonte.
        return data;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {

        return new FontResolverInfo(familyName);
    }

    private Stream? ReadFontFile(string faceName)
    {
        //Ler o arquivo de fonte incorporado no assembly
        var assembly = Assembly.GetExecutingAssembly();

        //Retorne aonde está o arquivo de fonte, o paramêtro faceName é o nome do arquivo sem a extensão.
        return assembly
       .GetManifestResourceStream($"MechanicalWorkshopManagment.Application.UseCase.StockMovementsUseCase.ReportsPDF.Fonts.{faceName}.ttf");
    }
}
