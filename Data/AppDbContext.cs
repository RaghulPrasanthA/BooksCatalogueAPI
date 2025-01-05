using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet representing the Books table
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {

                entity.ToTable("Books");

                //primary key definition
                entity.HasKey(e => e.Id);

                // Define properties and their mappings
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Publisher);


                entity.Property(e => e.Title);


                entity.Property(e => e.AuthorLastName);


                entity.Property(e => e.AuthorFirstName);


                entity.Property(e => e.Price);

                entity.Property(e => e.Year);
                entity.Property(e => e.City);
                entity.Property(e => e.JournalTitle);
                entity.Property(e => e.Volume);
                entity.Property(e => e.Month);
                entity.Property(e => e.PageNumber);
                entity.Property(e => e.TitleOfContainer);

                entity.Property(e => e.URL);

            });


        }
    }
}