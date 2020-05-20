using DempApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static DempApp.Data.Models.ConfigureDBRelations;

namespace DempApp.Data
{
    public class ApplicationDbConnection : IdentityDbContext
    {
        public ApplicationDbConnection(DbContextOptions<ApplicationDbConnection> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many(A company has multiple employees)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .OnDelete(DeleteBehavior.Cascade);

            //One to One
            modelBuilder.Entity<Author>()
               .HasOne(a => a.Biography)
               .WithOne(b => b.Author)
               .HasForeignKey<AuthorBiography>(b => b.AuthorRef);

            //Many to Many
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
