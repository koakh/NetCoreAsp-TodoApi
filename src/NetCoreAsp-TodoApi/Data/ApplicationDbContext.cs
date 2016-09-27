using Microsoft.EntityFrameworkCore;
using NetCoreAspTodoApi.Models.Movies;

namespace NetCoreAspTodoApi.Data
{
    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Movie> Movie { get; set; }
    }
}
