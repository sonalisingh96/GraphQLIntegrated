using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(r => r.Author)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(r => r.Isbn)
                .IsRequired();
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Title = "Harry Porter",
                    Author = "J. K. Rowling",
                    Isbn = "ISBN 978-9930943106"

                },
                new Book
                {
                    Title = "Famous Five",
                    Author = "Enid Blyton",
                    Isbn = "ISBN 978-9929801646"
                }


            );
        }
    }
}
