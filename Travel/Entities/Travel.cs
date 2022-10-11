using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Entities
{
    [Table("Travel")]
    public class TravelModel
    {
        public int? Id { get; set; }
        public int? Fund { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }

    }
}
