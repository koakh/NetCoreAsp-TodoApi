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
