using JobTracking.Services.Abstract;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace JobTracking.Services.Manager;

public class FileManager : IFileService
{
    public async Task<byte[]> ExportExcel<T>(List<T> list) where T : class, new()
    {
        ExcelPackage excelPackage = new();
        var excelBlank = excelPackage.Workbook.Worksheets.Add("Work1");
        excelBlank.Cells["A1"].LoadFromCollection(list, true, TableStyles.Light15);

        return await excelPackage.GetAsByteArrayAsync();
    }
}