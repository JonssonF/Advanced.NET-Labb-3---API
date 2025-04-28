namespace Labb3_API.Models.DTOs
{
    public class PersonLinksDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Links { get; set; } = new List<string>();
    }
}
