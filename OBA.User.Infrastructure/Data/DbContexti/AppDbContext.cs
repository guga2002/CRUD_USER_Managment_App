
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OBA.User.Core.Models;

namespace OBA.User.Infrastructure.Data.DbContexti
{
    public class AppDbContext :IdentityDbContext<Useri>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties...
        public DbSet<Useri> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> logs { get; set; }
    }
}
