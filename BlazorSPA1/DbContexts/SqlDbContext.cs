using BlazorSPA1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorSPA1.DbContexts
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
