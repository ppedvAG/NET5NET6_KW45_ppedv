namespace WebAPISample.Models
{
    public class LanguagesInCountry
    {
        public int Id { get; set; }
        public int CountryId { get; set; }  
        public int LanguageId { get; set; }

        public int Percent { get; set; }   
        

        public virtual Language LanguagesRef { get; set; }
        public virtual Country CountryRef { get; set; }
    }
}
