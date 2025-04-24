namespace Labb3_API.Models.DTOs
{
    public class PersonLinksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Interests { get; set; } = new List<string>();
        public string? SelfLink { get; set; }
        public string? PersonInterestsLink { get; set; }
        public string? InterestsLink { get; set; }
    }
}
