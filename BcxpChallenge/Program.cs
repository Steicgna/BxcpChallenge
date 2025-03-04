using BcxpChallenge.Models;
using BcxpChallenge.Maps;
using BcxpChallenge.Services;
using dotenv.net;
using Serilog;

DotEnv.Load();

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

// Weather Task
try
{
    var listWeather = OrchestratorService.
        GetListFromData<WeatherModel, WeatherMap>("WEATHER_CSV_DELIMITER", "Resources\\weather.csv");

    Log.Information($"Day with smallest Temperature Spread: {CalculateService.GetMinTemperatureSpreadByDay(listWeather)}");
}
catch (Exception ex)
{
    Log.Error($"There was a problem with the weather task. {ex.Message}");
}

// Country Task
try
{
    var listCountry = OrchestratorService.
        GetListFromData<CountryModel, CountryMap>("COUNTRY_CSV_DELIMITER", "Resources\\countries.csv");

    Log.Information($"Country with highest number of people per square kilometre: {CalculateService.GetMaxPopulationDensity(listCountry)}");
}
catch (Exception ex)
{
    Log.Error($"There was a problem with the country task. {ex.Message}");
}