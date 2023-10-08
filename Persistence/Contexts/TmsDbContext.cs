using Domain.Entities.TMS; 
using Microsoft.EntityFrameworkCore; 

namespace Persistence.Contexts;

public class TmsDbContext : DbContext
{
    public DbSet<TaskEntity> Task { get; set; }
    public DbSet<TaskFileEntity> TaskFile { get; set; } 
    
    public TmsDbContext(DbContextOptions<TmsDbContext> options) : base(options) { }
}