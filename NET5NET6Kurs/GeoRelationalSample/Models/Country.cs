namespace GeoRelationalSample.Models
{
    public class Country
    {
        public int Id { get; set; }
        public int ContinentId { get; set; }

        public string Name { get; set; }

        public virtual Continent ContinentRef { get; set; }

        public virtual ICollection<LanguagesInCountry> LanguagesInCountry { get; set; }
    }
}
