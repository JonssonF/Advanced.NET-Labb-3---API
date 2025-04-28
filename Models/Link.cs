using System.Text.Json.Serialization;

namespace Labb3_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        
        public int PersonId { get; set; }
        public int InterestId { get; set; }
        [JsonIgnore]
        public PersonInterest ? PersonInterest { get; set; }

    }
}
