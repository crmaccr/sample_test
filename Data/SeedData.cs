using System;
using System.Collections.Generic;
using System.Linq;
using test.Data;
using test.Models;

public class DataSeeder
{
    public static void SeedCountries(ApplicationDbContext context)
    {
        if (!context.Qualification.Any())
        {
            var qualifications = new List<Qualification>
            {
                new Qualification { Name = "SLC" },
                new Qualification {Name = "Intermediate" },
                new Qualification {Name = "BE" },
                new Qualification {Name = "ME" },
                new Qualification {Name = "PHD" },


            };
            context.AddRange(qualifications);
            context.SaveChanges();
        }
    }
}
