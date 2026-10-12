using Microsoft.EntityFrameworkCore;
using QuadraticEquation.Models;

namespace QuadraticEquation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EquationHistory> EquationHistories { get; set; }
    }
}