using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class DBConfig:DbContext
    {
        public DBConfig(DbContextOptions<DBConfig> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position>Positions { get; set; }
    }
}
