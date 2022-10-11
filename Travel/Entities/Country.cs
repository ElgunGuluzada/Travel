using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Entities
{
    [Table("Country")]
    public class Country:BaseIdentity
    {
        public List<City>? Cities { get; set; }
    }
}
