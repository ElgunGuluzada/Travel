using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Entities
{
    [Table("City")]

    public class City:BaseIdentity
    {
        public int? countryId { get; set; }
    }
}
