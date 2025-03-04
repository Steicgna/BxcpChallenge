using BcxpChallenge.Models;
using BcxpChallenge.Services;

namespace BcxpChallenge.Test.Services
{
    public class CalculateServiceTests
    {
        [Fact]
        public void GetMinTemperatureSpreadByDay_ValidInput_ReturnsCorrectDay()
        {
            var weatherList = new List<WeatherModel>
            {
                new() { Day = 1, MaxTemperature = 30, MinTemperature = 20 },
                new() { Day = 2, MaxTemperature = 25, MinTemperature = 22 },
                new() { Day = 3, MaxTemperature = 28, MinTemperature = 27 }
            };

            int day = CalculateService.GetMinTemperatureSpreadByDay(weatherList);

            Assert.Equal(3, day);
        }

        [Fact]
        public void GetMinTemperatureSpreadByDay_NegativeSpread_WritesToErrorConsole()
        {
            var weatherList = new List<WeatherModel>
            {
                new() { Day = 1, MaxTemperature = 10, MinTemperature = 20 },
                new() { Day = 2, MaxTemperature = 25, MinTemperature = 22 }
            };

            int day = CalculateService.GetMinTemperatureSpreadByDay(weatherList);

            Assert.Equal(1, day);
        }

        [Fact]
        public void GetMinTemperatureSpreadByDay_EmptyList_ThrowsException()
        {
            var weatherList = new List<WeatherModel>();

            Assert.Throws<Exception>(() => CalculateService.GetMinTemperatureSpreadByDay(weatherList));
        }

        [Fact]
        public void GetMinTemperatureSpreadByDay_NullList_ThrowsException()
        {
            List<WeatherModel> weatherList = null;

            Assert.Throws<Exception>(() => CalculateService.GetMinTemperatureSpreadByDay(weatherList));
        }

        [Fact]
        public void GetMaxPopulationDensity_ValidInput_ReturnsCorrectCountryName()
        {
            var countryList = new List<CountryModel>
            {
                new() { Name = "CountryA", Population = 1000000, Area = 10000 },
                new() { Name = "CountryB", Population = 2000000, Area = 5000 },
                new() { Name = "CountryC", Population = 500000, Area = 1000 }
            };

            string countryName = CalculateService.GetMaxPopulationDensity(countryList);

            Assert.Equal("CountryC", countryName);
        }

        [Fact]
        public void GetMaxPopulationDensity_EmptyList_ThrowsException()
        {
            var countryList = new List<CountryModel>();

            Assert.Throws<Exception>(() => CalculateService.GetMaxPopulationDensity(countryList));
        }

        [Fact]
        public void GetMaxPopulationDensity_NullList_ThrowsException()
        {
            List<CountryModel> countryList = null;

            Assert.Throws<Exception>(() => CalculateService.GetMaxPopulationDensity(countryList));
        }
    }
}