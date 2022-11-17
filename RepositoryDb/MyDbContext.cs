using Microsoft.EntityFrameworkCore;
using RepositoryDb.Models;


namespace RepositoryDb
{
    /// <summary>
    /// Db context
    /// </summary>
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<CalculatorHistory> CalculatorHistory { get; set; }
    }
}
