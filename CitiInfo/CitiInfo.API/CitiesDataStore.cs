using CitiInfo.API.Models;

namespace CitiInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        // Added the static property to retrun this class. this is part of singleton pattern network
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            // init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto() { Id = 1, Name = "New York City", Description="The one with big park."},
                new CityDto() { Id = 2, Name = "Antwrep", Description="The one with the cathedral that was never really finished."},
                new CityDto() { Id = 3, Name = "Paris", Description = "The one with the big tower"}
            };
        }

    }
}
