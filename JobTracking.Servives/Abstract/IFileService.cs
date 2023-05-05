namespace JobTracking.Services.Abstract;

public interface IFileService
{
    Task<byte[]> ExportExcel<T>(List<T> list) where T : class, new();
}
