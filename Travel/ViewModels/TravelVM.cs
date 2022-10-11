using Travel.Entities;

namespace Travel.ViewModels
{
    public class TravelVM
    {
        public int Fund { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }

    }
}
