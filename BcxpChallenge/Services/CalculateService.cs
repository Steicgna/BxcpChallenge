using BcxpChallenge.Models;
using Serilog;

namespace BcxpChallenge.Services
{
    public static class CalculateService
    {
        public static int GetMinTemperatureSpreadByDay(List<WeatherModel> inputList)
        {
            if (inputList is not null && inputList.Count != 0)
            {
                var minDataset = inputList.MinBy(static elem => elem.TemperatureSpread);
                if(minDataset.TemperatureSpread < 0)
                {
                    Log.Warning($"There seems to be a problem with dataset of day {minDataset.Day}. " +
                        $"The temparature spread is negative: {minDataset.TemperatureSpread}");
                }
                return minDataset.Day;
            }
            else
            {
                Log.Error("Input List is null or empty");
                throw new Exception();
            }
        }

        public static string GetMaxPopulationDensity(List<CountryModel> inputList)
        {
            if (inputList is not null && inputList.Count != 0)
            {
                return inputList.MaxBy(elem => elem.PopulationDensity).Name;
            }
            else
            {
                Log.Error("Input List is null or empty");
                throw new Exception();
            }
        }
    }
}
