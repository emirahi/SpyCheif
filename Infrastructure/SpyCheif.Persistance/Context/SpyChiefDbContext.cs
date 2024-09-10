

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


    }
}
