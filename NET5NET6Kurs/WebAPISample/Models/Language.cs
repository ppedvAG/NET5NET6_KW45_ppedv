namespace WebAPISample.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanguagesInCountry> LanguagesInCountries { get; set; }
    }
}
