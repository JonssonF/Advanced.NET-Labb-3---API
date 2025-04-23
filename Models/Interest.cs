﻿namespace Labb3_API.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();

    }
}
