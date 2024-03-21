using Reception_system.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Reception_system.DAL
{
    public class ReceptionDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }

        public ReceptionDbContext(DbContextOptions<ReceptionDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }


}
