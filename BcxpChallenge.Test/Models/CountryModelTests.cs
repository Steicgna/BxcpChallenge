using BcxpChallenge.Models;

namespace BcxpChallenge.Test.Models
{
    public class CountryModelTests
    {
        [Fact]
        public void PopulationDensity_ValidValues_CalculatesCorrectly()
        {
            var country = new CountryModel
            {
                Name = "Test",
                Population = 1000000,
                Area = 10000
            };

            double density = country.PopulationDensity;

            Assert.Equal(100, density);
        }

        [Fact]
        public void PopulationDensity_AreaZero_ReturnsNaN()
        {
            var country = new CountryModel
            {
                Name = "Testland",
                Population = 1000000,
                Area = 0
            };

            double density = country.PopulationDensity;

            Assert.True(double.IsNaN(density));
        }
    }
}