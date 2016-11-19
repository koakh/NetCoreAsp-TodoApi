#### Mock Data

- [Mockaroo ](https://www.mockaroo.com/)
> Mockaroo lets you generate up to 1,000 rows of realistic test data in CSV, JSON, SQL, and Excel formats.

- [Bogus for .NET/C#](https://github.com/bchavez/Bogus)
```
Install-Package Bogus
```

- [C# library to populate object with random data](http://stackoverflow.com/questions/6625490/c-sharp-library-to-populate-object-with-random-data)
- [Playing around with GenFu](http://asp.net-hacker.rocks/2016/01/27/playing-around-with-GenFu.html)

----
#### MySQL

- [MySQL (Official)](https://docs.efproject.net/en/latest/providers/mysql/index.html)
- [HowTo: Starting with MySQL EF Core provider and Connector/Net 7.0.4](http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/)

Install the MySql.Data.EntityFrameworkCore NuGet package.

```
PM > Install-Package MySql.Data.EntityFrameworkCore -Pre
```

or add to 

[project.json]

```
{
  "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.0.1",
      "type": "platform"
    },
	...
    "MySql.Data.EntityFrameworkCore": "7.0.5-IR21"
  },
```

add to 

[appsettings.json]
```
{
  "ConnectionStrings": {
    //"DefaultConnection": "server=localhost;userid=guest;pwd=guest;port=3306;database=test;sslmode=none;",
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-MvcMovie-63eef4dc-62e6-4e63-8219-81787069514a;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```

add to 

[Startup.cs]

```
string connectionstring = configuration.getconnectionstring("defaultconnection");
var entry = new movie() { title = "foobar" };
using (var context = applicationdbcontextfactory.create(connectionstring))
{
    context.add(entry);
    context.savechanges();
}
console.writeline($"employee was saved in the database with id: {entry.id}");
```
add

[Data\ApplicationDbContextFactory.cs]

```
using Microsoft.EntityFrameworkCore;

namespace NetCoreAspTodoApi.Data
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
```


Add AddIdentity

Add 
	Models\AccountViewModels\
	Models\ManageViewModels\
	Models\ApplicationUser.cs

from other project

change namespace to NetCoreAspTodoApi.Models.?

Add to startup above AddDbContext

[Startup.cs]

//Register the ApplicationDbContext in DI container
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

add to 

[project.json]
    "Microsoft.AspNetCore.Identity.EntityFrameworkCore": "1.0.0",
    "Microsoft.EntityFrameworkCore.SqlServer": "1.0.1"

add to 

[appsettings.json]

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-MvcMovie-63eef4dc-62e6-4e63-8219-81787069514a;Trusted_Connection=True;MultipleActiveResultSets=true"
  },

add

[Models\SeedData.cs]

Link to Swagger
    http://localhost:5000/swagger/ui
    http://localhost:5000/swagger/v1/swagger.json
