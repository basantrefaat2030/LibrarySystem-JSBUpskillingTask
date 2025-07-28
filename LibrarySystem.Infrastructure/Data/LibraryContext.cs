using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem_JSBUpskillingTask.Data
{
    public class LibraryContext :DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        //fluent API to configure the relationship between Book and Category
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Category)
            //    .WithMany(c => c.Books)
            //    .HasForeignKey(b => b.CategoryId);

            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Fiction", Description = "Fiction books" },
                new Category { CategoryId = 2, Name = "Science", Description = "Science books" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "The Great Novel",
                    Description = "A great fiction book",
                    Price = 130.00m,
                    Author = "John Doe",
                    Stock = 10,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Name = "Introduction to Physics",
                    Description = "Basic physics concepts",
                    Price = 100.00m,
                    Author = "Jane Smith",
                    Stock = 5,
                    CategoryId = 2
                }
            );
        }
    }
}
