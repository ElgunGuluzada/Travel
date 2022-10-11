namespace Travel.Entities
{
    public class Country:BaseIdentity
    {
        public List<City>? Cities { get; set; }
    }
}
