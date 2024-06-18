using Eventify.Domain.Common;
using Eventify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Persistence.DbContexts
{
    public class EventifyDbContext:DbContext
    {
        public DbSet<Event> events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsOne(x => x.Location);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EventifyDb");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<EntityBase>();

            if(data is not null)
            {
                foreach (var item in data)
                {
                    if (item.State == EntityState.Added)
                        item.Entity.CreateDate = DateTimeOffset.UtcNow;

                    else if (item.State == EntityState.Modified)
                        item.Entity.UpdateDate = DateTimeOffset.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
