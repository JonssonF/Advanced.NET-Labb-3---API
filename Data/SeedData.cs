using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Data
{
    public static class SeedData
    {
        public static async Task Initialize(AppDbContext context)
        {
            if (context.Persons.Any())
                return;

            // Skapa 5 intressen
            var interests = new List<Interest>
            {
                new Interest { Title = "Music", Description = "Listening and playing music" },
                new Interest { Title = "Coding", Description = "Writing code and building projects" },
                new Interest { Title = "Hiking", Description = "Exploring mountains and nature" },
                new Interest { Title = "Cooking", Description = "Making and eating good food" },
                new Interest { Title = "Gaming", Description = "Playing games of all kinds" }
            };

            await context.Interests.AddRangeAsync(interests);
            await context.SaveChangesAsync();

            // Skapa 10 personer
            var persons = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                persons.Add(new Person
                {
                    Name = $"Person {i}",
                    PhoneNumber = $"070-12{i:D3}-{i * 11:D4}"
                });
            }

            await context.Persons.AddRangeAsync(persons);
            await context.SaveChangesAsync();

            // Lista med 15 länkar
            var urls = new List<string>
            {
                "https://youtube.com",
                "https://github.com",
                "https://spotify.com",
                "https://stackoverflow.com",
                "https://reddit.com",
                "https://trails.com",
                "https://bbc.com",
                "https://twitch.tv",
                "https://unity.com",
                "https://dotnet.microsoft.com",
                "https://allrecipes.com",
                "https://steamcommunity.com",
                "https://medium.com",
                "https://linkedin.com",
                "https://play.google.com"
            };

            var rand = new Random();

            foreach (var person in persons)
            {
                var personInterests = interests
                    .OrderBy(_ => rand.Next())
                    .Take(rand.Next(2, 4)) // varje person får 2–3 intressen
                    .ToList();

                foreach (var interest in personInterests)
                {
                    var personInterest = new PersonInterest
                    {
                        PersonId = person.Id,
                        InterestId = interest.Id
                    };

                    // 1–3 länkar per person-intresse
                    var linksToAdd = rand.Next(1, 4);
                    for (int i = 0; i < linksToAdd; i++)
                    {
                        var url = urls[rand.Next(urls.Count)];
                        personInterest.Links.Add(new Link
                        {
                            Url = url
                        });
                    }

                    context.PersonInterests.Add(personInterest);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
