using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    
    public class PersonInterest
    {   
        // Many to many relations Person/Interest
        public int PersonId { get; set; }
        [JsonIgnore]
        public Person? Person { get; set; }

        public int InterestId { get; set; }
        [JsonIgnore]
        public Interest? Interest { get; set; }

        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
