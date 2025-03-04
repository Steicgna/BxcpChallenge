
namespace BcxpChallenge.Models
{
    public class WeatherModel
    {
        public int Day { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        // How to handle negative spread values? Throw Error? Log Warning? switch values?
        public float TemperatureSpread => MaxTemperature - MinTemperature;
    }
}
