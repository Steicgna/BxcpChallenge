using BcxpChallenge.Maps;
using BcxpChallenge.Models;
using BcxpChallenge.Services;

namespace BcxpChallenge.Test.Services
{
    public class OrchestratorServiceTests
    {
        [Fact]
        public void GetListFromData_ValidData_ReturnsCorrectRecords()
        {
            string filePath = "testfile_w.csv";
            string delimiterEnv = "TEST_DELIMITER";
            string delimiter = ",";
            string csvData = "Day,MxT,MnT\n1,30,20\n2,25,18";

            File.WriteAllText(filePath, csvData);
            Environment.SetEnvironmentVariable(delimiterEnv, delimiter);

            var records = OrchestratorService.GetListFromData<WeatherModel, WeatherMap>(delimiterEnv, filePath);

            Assert.Equal(2, records.Count);
            Assert.Equal(1, records[0].Day);
            Assert.Equal(30, records[0].MaxTemperature);
            Assert.Equal(20, records[0].MinTemperature);
            Assert.Equal(2, records[1].Day);
            Assert.Equal(25, records[1].MaxTemperature);
            Assert.Equal(18, records[1].MinTemperature);

            File.Delete(filePath);
            Environment.SetEnvironmentVariable(delimiterEnv, null);
        }

        [Fact]
        public void GetListFromData_SemicolonDelimiter_ReturnsCorrectRecords()
        {
            string filePath = "testfile.csv";
            string delimiterEnv = "TEST_DELIMITER";
            string delimiter = ";";
            string csvData = "Day;MxT;MnT\n1;30;20";

            File.WriteAllText(filePath, csvData);
            Environment.SetEnvironmentVariable(delimiterEnv, delimiter);

            var records = OrchestratorService.GetListFromData<WeatherModel, WeatherMap>(delimiterEnv, filePath);

            Assert.Single(records);
            Assert.Equal(1, records[0].Day);

            File.Delete(filePath);
            Environment.SetEnvironmentVariable(delimiterEnv, null);
        }

        [Fact]
        public void GetListFromData_CountryData_ReturnsCorrectRecords()
        {
            string filePath = "testfile.csv";
            string delimiterEnv = "TEST_DELIMITER";
            string delimiter = ",";
            string csvData = "Name,Population,Area (km²)\nTestland,1.000.000,10.000";

            File.WriteAllText(filePath, csvData);
            Environment.SetEnvironmentVariable(delimiterEnv, delimiter);

            var records = OrchestratorService.GetListFromData<CountryModel, CountryMap>(delimiterEnv, filePath);

            Assert.Single(records);
            Assert.Equal("Testland", records[0].Name);
            Assert.Equal(1000000, records[0].Population);
            Assert.Equal(10000, records[0].Area);

            File.Delete(filePath);
            Environment.SetEnvironmentVariable(delimiterEnv, null);
        }
    }
}