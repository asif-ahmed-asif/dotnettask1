using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
    }
}
