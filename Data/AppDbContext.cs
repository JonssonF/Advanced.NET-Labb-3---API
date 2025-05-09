﻿using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PersonId & InterestId uses the same primarykey
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            //One to many, person -> interesest
            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            //One to many, interest -> person
            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            //PersonInterest to certain link, PI can have many links
            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => new { l.PersonId, l.InterestId });
        }

    }
}
