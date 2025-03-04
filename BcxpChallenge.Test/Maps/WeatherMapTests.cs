using BcxpChallenge.Maps;
using BcxpChallenge.Models;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace BcxpChallenge.Test.Maps
{
    public class WeatherMapTests
    {
        [Fact]
        public void WeatherMap_MapsPropertiesCorrectly()
        {
            var map = new WeatherMap();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);

            var memberMaps = map.MemberMaps;

            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(WeatherModel.Day) && m.Data.Names.Contains("Day")));
            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(WeatherModel.MaxTemperature) && m.Data.Names.Contains("MxT")));
            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(WeatherModel.MinTemperature) && m.Data.Names.Contains("MnT")));
        }

        [Fact]
        public void WeatherMap_ReadsDataCorrectly()
        {
            string csvData = "Day,testvalue,MxT,MnT\n1,123,30,20\n2,456,25,18";
            using var reader = new StringReader(csvData);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<WeatherMap>();

            var records = csv.GetRecords<WeatherModel>().ToList();

            Assert.Equal(2, records.Count);
            Assert.Equal(1, records[0].Day);
            Assert.Equal(30, records[0].MaxTemperature);
            Assert.Equal(20, records[0].MinTemperature);
            Assert.Equal(2, records[1].Day);
            Assert.Equal(25, records[1].MaxTemperature);
            Assert.Equal(18, records[1].MinTemperature);
        }
    }
}