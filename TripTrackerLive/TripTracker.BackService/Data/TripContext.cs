using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TripTracker.BackService.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        public TripContext() { }

        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any()) return;

                context.Trips.AddRange(new Trip[]
                    {
                    new Trip
                    {
                        Id = 0,
                        Name = "MVP Summit",
                        StartDate = new DateTime(2019,3,5),
                        EndTime = new DateTime(2019,3,8)
                    },
                    new Trip
                    {
                        Id = 1,
                        Name = "DevInterSection Orlando 2018",
                        StartDate = new DateTime(2019,3,25),
                        EndTime = new DateTime(2019,3,27)
                    },
                    new Trip
                    {
                        Id = 2,
                        Name = "Build 2019",
                        StartDate = new DateTime(2019,5,7),
                        EndTime = new DateTime(2019,5,9)
                    }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
