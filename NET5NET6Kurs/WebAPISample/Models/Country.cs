using System.Xml.Serialization;

namespace WebAPISample.Models
{
    public class Country
    {
        public int Id { get; set; }
        public int ContinentId { get; set; }

        public string Name { get; set; }


        [XmlIgnore]
        public virtual Continent ContinentRef { get; set; }
        
        [XmlIgnore]
        public virtual ICollection<LanguagesInCountry> LanguagesInCountry { get; set; }
    }
}
