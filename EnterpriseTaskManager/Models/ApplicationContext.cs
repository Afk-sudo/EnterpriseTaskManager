
using Microsoft.EntityFrameworkCore;

namespace EnterpriseTaskManager.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
        }
    }
}
