

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpyCheif.Domain.Entity;

namespace SpyCheiif.Persistance.Context
{
    public class SpyChiefDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public SpyChiefDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Asset>().Navigation(asset => asset.Type).AutoInclude();
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return base.SaveChanges();
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<ServiceDatabase> ServiceDatabases { get; set; }


    }
}
