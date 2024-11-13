using Microsoft.EntityFrameworkCore;
using PracticeC_.Models;

namespace PracticeC_.Data;
public class ApplicationDbContext: DbContext
{
    public DbSet<Room_type> Room_types {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}