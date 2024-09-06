

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



    }
}
