using BcxpChallenge.Models;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using BcxpChallenge.Maps;

namespace BcxpChallenge.Test.Maps
{
    public class CountryMapTests
    {
        [Fact]
        public void CountryMap_MapsPropertiesCorrectly()
        {
            var map = new CountryMap();
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);

            var memberMaps = map.MemberMaps;

            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(CountryModel.Name) && m.Data.Names.Contains("Name")));
            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(CountryModel.Population)));
            Assert.Single(memberMaps.Where(m => m.Data.Member.Name == nameof(CountryModel.Area)));
        }

        [Fact]
        public void CountryMap_PopulationConversion_HandlesDecimalPoints()
        {
            var csv = "Name,Population,Area (km²)\nTest,1.000.000,10000";
            var reader = new StringReader(csv);
            var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csvReader.Context.RegisterClassMap<CountryMap>();

            csvReader.Read();
            var record = csvReader.GetRecord<CountryModel>();

            Assert.Equal(1000000, record.Population);
        }

        [Fact]
        public void CountryMap_AreaConversion_HandlesDecimalPoints()
        {
            var csv = "Name,Population,Area (km²)\nTest,1000000,10.000";
            var reader = new StringReader(csv);
            var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csvReader.Context.RegisterClassMap<CountryMap>();

            csvReader.Read();
            var record = csvReader.GetRecord<CountryModel>();

            Assert.Equal(10000, record.Area);
        }

        [Fact]
        public void CountryMap_ReadsDataCorrectly()
        {
            string csvData = "Name,testvalue,Population,Area (km²)\nTest,abc,1000000,10.000\nTest2,def,100,2";
            using var reader = new StringReader(csvData);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<CountryMap>();

            var records = csv.GetRecords<CountryModel>().ToList();

            Assert.Equal(2, records.Count);
            Assert.Equal("Test", records[0].Name);
            Assert.Equal(1000000, records[0].Population);
            Assert.Equal(10000, records[0].Area);
            Assert.Equal("Test2", records[1].Name);
            Assert.Equal(100, records[1].Population);
            Assert.Equal(2, records[1].Area);
        }
    }
}