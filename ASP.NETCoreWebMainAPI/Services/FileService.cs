using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace ASP.NETCoreWebMainAPI.Services
{
    public class FileService : IFileService
    {
        public async Task WriteToFileAsync(string filePath, string content)
        {
            try
            {
                await using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    await writer.WriteLineAsync(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
                throw;
            }
        }
    }
}