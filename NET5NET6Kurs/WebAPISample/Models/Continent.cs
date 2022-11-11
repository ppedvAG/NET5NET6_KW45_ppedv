using System.Xml.Serialization;

namespace WebAPISample.Models
{
    public class Continent
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [XmlIgnore]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
