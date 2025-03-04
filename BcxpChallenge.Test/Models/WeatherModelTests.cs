using BcxpChallenge.Models;

namespace BcxpChallenge.Test.Models
{
    public class WeatherModelTests
    {
        [Fact]
        public void TemperatureSpread_CalculatesCorrectly()
        {
            var weather = new WeatherModel
            {
                MaxTemperature = 30.5f,
                MinTemperature = 20.5f
            };

            float spread = weather.TemperatureSpread;

            Assert.Equal(10.0f, spread);
        }

        [Fact]
        public void TemperatureSpread_NegativeTemperatures_CalculatesCorrectly()
        {
            var weather = new WeatherModel
            {
                MaxTemperature = -5.0f,
                MinTemperature = -15.0f
            };

            float spread = weather.TemperatureSpread;

            Assert.Equal(10.0f, spread);
        }

        [Fact]
        public void TemperatureSpread_MaxTemperatureLessThanMinTemperature_CalculatesCorrectly()
        {
            WeatherModel weather = new()
            {
                MaxTemperature = 10f,
                MinTemperature = 20f
            };

            float spread = weather.TemperatureSpread;

            Assert.Equal(-10f, spread);
        }
    }
}