using BcxpChallenge.Interfaces;
using BcxpChallenge.Maps;
using BcxpChallenge.Models;
using BcxpChallenge.Services;
using Moq;

namespace BcxpChallenge.Test.Services
{
    public class CsvDataServiceTests
    {
        [Fact]
        public void ParseData_ValidData_ReturnsCorrectRecords()
        {
            var csvData = "Day,MxT,MnT\n1,30,20\n2,25,18";
            var mockReader = new Mock<IDataReader>();
            mockReader.Setup(r => r.GetReader()).Returns(new StringReader(csvData));
            var dataService = new CsvDataService<WeatherModel, WeatherMap>();

            var records = dataService.ParseData(mockReader.Object);

            Assert.Equal(2, records.Count);
            Assert.Equal(1, records[0].Day);
            Assert.Equal(30, records[0].MaxTemperature);
            Assert.Equal(20, records[0].MinTemperature);
            Assert.Equal(2, records[1].Day);
            Assert.Equal(25, records[1].MaxTemperature);
            Assert.Equal(18, records[1].MinTemperature);
        }

        [Fact]
        public void SetDelimiter_ValidDelimiter_SetsConfiguration()
        {
            var csvData = "Day;MxT;MnT\n1;30;20";
            var mockReader = new Mock<IDataReader>();
            mockReader.Setup(r => r.GetReader()).Returns(new StringReader(csvData));
            var dataService = new CsvDataService<WeatherModel, WeatherMap>();

            dataService.SetDelimiter(";");
            var records = dataService.ParseData(mockReader.Object);

            Assert.Single(records);
            Assert.Equal(1, records[0].Day);
        }

        [Fact]
        public void SetDelimiter_NullOrEmptyDelimiter_DoesNotChangeConfiguration()
        {
            var csvData = "Day,MxT,MnT\n1,30,20";
            var mockReader = new Mock<IDataReader>();
            mockReader.Setup(r => r.GetReader()).Returns(new StringReader(csvData));
            var dataService = new CsvDataService<WeatherModel, WeatherMap>();

            dataService.SetDelimiter(null);
            var records = dataService.ParseData(mockReader.Object);

            Assert.Single(records);
            Assert.Equal(1, records[0].Day);
        }

        [Fact]
        public void ParseData_CountryModel_WorksCorrectly()
        {
            string csvData = "Name,Population,Area (km²)\nTest,1.000.000,10.000";
            var mockReader = new Mock<IDataReader>();
            mockReader.Setup(r => r.GetReader()).Returns(new StringReader(csvData));
            var dataService = new CsvDataService<CountryModel, CountryMap>();

            var records = dataService.ParseData(mockReader.Object);

            Assert.Single(records);
            Assert.Equal("Test", records[0].Name);
            Assert.Equal(1000000, records[0].Population);
            Assert.Equal(10000, records[0].Area);
        }
    }
}