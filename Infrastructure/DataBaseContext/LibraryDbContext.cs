using DomainProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureProject.DataBaseContext;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    DbSet<Book> Books { get; set; }
    DbSet<ReturnBook> ReturnedBooks { get; set; }
    DbSet<Loan> Loans { get; set; }
    DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(x => x.BookId);
            entity.Property(x => x.BookName).HasMaxLength(256);
            entity.Property(x => x.Quantity).IsRequired();
            entity.HasMany(b => b.Loan)
            .WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.UserId);
            entity.Property(x => x.Name).HasMaxLength(100);
            entity.Property(x => x.Address).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Cellphone).IsRequired().HasMaxLength(13);
            entity.Property(x => x.City).IsRequired().HasMaxLength(25);
            entity.HasMany(u => u.Loan)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
