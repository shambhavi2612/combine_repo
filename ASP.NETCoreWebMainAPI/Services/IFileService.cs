namespace ASP.NETCoreWebMainAPI.Services
{
    public interface IFileService
    {
        Task WriteToFileAsync(string filePath, string content);
    }




}
