using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace NetCoreAspTodoApi.Models
{
    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class EmployeesContextFactory
    {
        public static EmployeesContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new EmployeesContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
