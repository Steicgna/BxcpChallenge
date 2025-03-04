using BcxpChallenge.Models;
using CsvHelper.Configuration;

namespace BcxpChallenge.Maps
{
    public class CountryMap : ClassMap<CountryModel>
    {
        public CountryMap()
        {
            Map(country => country.Name).Name("Name");
            Map(country => country.Population).Convert(args => (long)Convert.ToDouble(args.Row.GetField("Population").Replace(".", "")));
            Map(country => country.Area).Convert(args => Convert.ToDouble(args.Row.GetField("Area (km²)").Replace(".", "")));
        }
    }
}
