using inventory.Model;
using Microsoft.EntityFrameworkCore;
namespace inventory.Data
{


  public class ApplicationDbContext : DbContext
  {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
      {
      
       }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Product> Products { get; set; }
  }

}
// dotnet ef migrations add InitialCreate
// dotnet ef database update
// dotnet ef migrations add Product 
// dotnet ef migrations
// dotnet ef migrations add InitialCreate -o Data/Migrations
//https://www.learnentityframeworkcore.com/migrations?
// dotnet add package Migrations --version 6.0.0