using Microsoft.EntityFrameworkCore;
namespace NetCoreAspTodoApi.Models
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }
}
