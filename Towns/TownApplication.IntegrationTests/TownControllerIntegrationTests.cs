namespace TownApplication.IntegrationTests
{
    public class TownControllerIntegrationTests
    {
        private readonly TownController _controller;

        public TownControllerIntegrationTests()
        {
            _controller = new TownController();
            _controller.ResetDatabase();
        }

        [Fact]
        public void AddTown_ValidInput_ShouldAddTown()
        {
            
            var validTownname = "ValidTownName";
            var population = 100;
            
            _controller.AddTown(validTownname, population);
          
            var result = _controller.GetTownByName(validTownname);
            Assert.NotNull(result);
            Assert.StrictEqual(population, result.Population);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("AB")]
        public void AddTown_InvalidName_ShouldThrowArgumentException(string invalidName)
        {
           
            var population = 100;
            
            var exception = Assert.Throws<ArgumentException>(() => _controller.AddTown(invalidName, population));
            Assert.Equal("Invalid town name.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddTown_InvalidPopulation_ShouldThrowArgumentException(int invalidPopulation)
        {
            
            var townName = "Sofia";
            
            var exception = Assert.Throws<ArgumentException>(() => _controller.AddTown(townName, invalidPopulation));
           
            Assert.Equal("Population must be a positive number.", exception.Message);
        }

        [Fact]
        public void AddTown_DuplicateTownName_DoesNotAddDuplicateTown()
        {
            
            var townName = "Sofia";
            var population = 100;

            _controller.AddTown(townName, population);

            _controller.AddTown(townName, population);

            var result = _controller.ListTowns();
            Assert.Single(result);
            var item = result[0];
            Assert.Equal(population, item.Population);
            Assert.Equal(townName, item.Name);
        }

        [Fact]
        public void UpdateTown_ShouldUpdatePopulation()
        {
          
            var townName = "Plovdiv";
            var initialPopulation = 1000;
            var updatedPopulation = 2000;
            _controller.AddTown(townName, initialPopulation);
            
            var town = _controller.GetTownByName(townName);
            _controller.UpdateTown(town.Id, updatedPopulation);
          
            var updatedTown = _controller.GetTownByName(townName);
            Assert.NotNull(updatedTown);
            Assert.Equal(updatedPopulation, updatedTown.Population);
        }

        [Fact]
        public void DeleteTown_ShouldDeleteTown()
        {
            
            var townName = "Varna";
            var population = 1234;
            _controller.AddTown(townName, population);
          
            var town = _controller.GetTownByName(townName);
            _controller.DeleteTown(town.Id);
        
            var deletedTown = _controller.GetTownByName(townName);
            Assert.Null(deletedTown);
        }

        [Fact]
        public void ListTowns_ShouldReturnTowns()
        {
           
            var towns = new List<string>{ "Sofia", "Plovdiv", "Varna", "Burgas", "Ruse"};

            foreach (var town in towns)
            {
                _controller.AddTown(town, town.Length * 1000);
            }
         
            var allTowns = _controller.ListTowns();

            Assert.Equal(towns.Count, allTowns.Count);

            foreach (var town in towns)
            {
                var existingTown = allTowns.FirstOrDefault(t => t.Name == town);
                Assert.NotNull(existingTown);
                Assert.Equal(town.Length * 1000, existingTown.Population);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void UpdateTown_WithInvalidPopulation_ShouldThrowArgumentException(int invalidPopulation)
        {
            var townName = "Sofia";
            var initialPopulation = 100;

            _controller.AddTown(townName, initialPopulation);

            var town = _controller.GetTownByName(townName);
            var action = () => _controller.UpdateTown(town.Id, invalidPopulation);

            var exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Population must be a positive number.", exception.Message);

        }

    }
}
