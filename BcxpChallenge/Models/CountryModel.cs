
namespace BcxpChallenge.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public double PopulationDensity
        {
            get
            {
                if (Area == 0)
                {
                    return double.NaN;
                }

                return Population / Area;
            }
        }
    }
}
