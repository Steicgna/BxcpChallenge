using BcxpChallenge.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BcxpChallenge.Services
{
    public class CsvDataService<T, Map> : IDataParser<T> where Map : ClassMap<T>
    {
        private CsvConfiguration CsvConfiguration { get; set; }

        public CsvDataService()
        {
            CsvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
        }

        public void SetDelimiter(string delimiter)
        {
            if (!string.IsNullOrEmpty(delimiter))
            {
                CsvConfiguration.Delimiter = delimiter;
            }
        }

        public List<T> ParseData(IDataReader dataReader)
        {
            using var reader = dataReader.GetReader();
            using var csv = new CsvReader(reader, CsvConfiguration);
            csv.Context.RegisterClassMap<Map>();
            return csv.GetRecords<T>().ToList();
        }
    }
}
