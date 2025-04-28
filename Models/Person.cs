using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Person
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
