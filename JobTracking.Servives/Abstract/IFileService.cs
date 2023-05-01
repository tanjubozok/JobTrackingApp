namespace JobTracking.Servives.Abstract;

public interface IFileService
{
    Task<byte[]> ExportExcel<T>(List<T> list) where T : class, new();
}
