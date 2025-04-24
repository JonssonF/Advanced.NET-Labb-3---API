namespace Labb3_API.Models.DTOs
{
    public class PersonDetailsDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<PersonInterestDTO> PersonInterests { get; set; } = new List<PersonInterestDTO>();
    }
}
