using Microsoft.EntityFrameworkCore;
using RepositoryDb.Models;


namespace RepositoryDb
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<CalculatorHistory> CalculatorHistory { get; set; }
    }
}
