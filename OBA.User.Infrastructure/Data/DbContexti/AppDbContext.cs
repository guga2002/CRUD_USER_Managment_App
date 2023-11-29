using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OBA.User.Core.Models;
using OBA.User.Core.Models.Resource;

namespace OBA.User.Infrastructure.Data.DbContexti
{
    public class AppDbContext :IdentityDbContext<Useri,Identityroleb,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public AppDbContext()
        {
        }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> logs { get; set; }
        public DbSet<Address>  Addresses { get; set; } 
        public DbSet<Company>  Companies { get; set; }
        public DbSet<Coment>  Comments { get; set; }
        public DbSet<Photo>  Photos{ get; set; }
        public DbSet<ToDo>  Todos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User_Post> Posts { get; set; }
    }
}
