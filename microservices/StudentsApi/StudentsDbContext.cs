using Microsoft.EntityFrameworkCore;

namespace StudentsApi;

public class StudentsDbContext : DbContext
{
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options) {} 
    
    public DbSet<Student> Students { get; set; }
}