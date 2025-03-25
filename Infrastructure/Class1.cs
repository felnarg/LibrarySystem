using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    DbSet<>
}
