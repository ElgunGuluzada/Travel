namespace Travel.Filter
{
    public class Filtering
    {
        public FilterTravels Filter { get; set; }
    }

    public enum FilterTravels
    {
        A_Z = 1,
        Z_A,
        Country,
    }
}
