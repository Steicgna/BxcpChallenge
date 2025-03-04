using BcxpChallenge.Models;
using CsvHelper.Configuration;

namespace BcxpChallenge.Maps
{
    public class WeatherMap : ClassMap<WeatherModel>
    {
        public WeatherMap()
        {
            Map(weather => weather.Day).Name("Day");
            Map(weather => weather.MaxTemperature).Name("MxT");
            Map(weather => weather.MinTemperature).Name("MnT");
        }
    }
}
