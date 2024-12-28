using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookMate.Data_Models
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
