using Microsoft.EntityFrameworkCore;
using Students.Model;

namespace Students.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsModel>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<StudentsModel>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()"); // Default to current date and time (SQL Server)
        }

        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
    }

}
