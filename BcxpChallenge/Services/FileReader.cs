using BcxpChallenge.Interfaces;
using Serilog;

namespace BcxpChallenge.Services
{
    public class FileReader(string filePath) : IDataReader
    {
        private readonly string FilePath = filePath;

        public TextReader GetReader()
        {
            try
            {
                return new StreamReader(FilePath);
            }
            catch (FileNotFoundException ex)
            {
                Log.Error($"File not found: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error($"Error while opening the file: {ex.Message}");
                throw;
            }
        }
    }
}
