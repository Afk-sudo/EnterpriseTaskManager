using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EnterpriseTaskManager.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TaskCategory> TaskCategoryes { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<MainUser> MainUsers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEmployee>().HasKey(t => new { t.TaskId, t.EmployeeId });
            modelBuilder.Entity<TaskEmployee>().HasOne(e => e.Employee).WithMany(t => t.TaskEmployee).HasForeignKey(et => et.TaskId);
            modelBuilder.Entity<TaskEmployee>().HasOne(t => t.Task).WithMany(e => e.TaskEmployee).HasForeignKey(et => et.EmployeeId);
        }
    }
}
