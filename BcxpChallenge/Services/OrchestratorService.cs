using CsvHelper.Configuration;

namespace BcxpChallenge.Services
{
    public static class OrchestratorService
    {
        public static List<T> GetListFromData<T, Map>(string delimiterEnv, string filePath) where Map : ClassMap<T>
        {
            var parseService = new CsvDataService<T, Map>();
            parseService.SetDelimiter(Environment.GetEnvironmentVariable(delimiterEnv));

            var csvReader = new FileReader(filePath);
            return parseService.ParseData(csvReader);
        }
    }
}
