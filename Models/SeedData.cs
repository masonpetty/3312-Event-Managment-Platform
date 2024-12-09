using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EventManagementPlatform.Models;

namespace EventManagementPlatform.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EventManagementContext(
                serviceProvider.GetRequiredService<DbContextOptions<EventManagementContext>>()))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Look for any events
                if (context.Events.Any())
                {
                    return;   // DB has been seeded
                }

                // Add more events to ensure at least 25 records for paging
                for (int i = 1; i <= 25; i++)
                {
                    context.Events.Add(new Event
                    {
                        Name = $"Event {i}",
                        Description = $"Description for Event {i}",
                        StartTime = DateTime.Today.AddDays(i),
                        EndTime = DateTime.Today.AddDays(i + 2),
                    });
                }

                context.SaveChanges();
            }
        }
    }
}