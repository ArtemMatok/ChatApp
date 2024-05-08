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
        public DbSet<MediaAccount> MediaAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(x =>
            {
                x.HasOne(m => m.ToUser).WithMany().OnDelete(DeleteBehavior.NoAction);
                x.HasOne(m => m.FromUser).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
