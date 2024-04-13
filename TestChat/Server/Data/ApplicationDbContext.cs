using Microsoft.EntityFrameworkCore;
using TestChat.Server.Data.Entities;

namespace TestChat.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                    
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }


    }
}
