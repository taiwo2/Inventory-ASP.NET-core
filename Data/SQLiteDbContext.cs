using inventory.Model;
using Microsoft.EntityFrameworkCore;
namespace inventory.Data
{


  public class SQLiteDbContext : DbContext
  {
      public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) 
      {
      
       }
      public DbSet<Patient> Patients { get; set; }
  }

}
// dotnet ef migrations add InitialCreate
// dotnet ef database update
// dotnet ef migrations add Product 
// dotnet ef migrations
//https://www.learnentityframeworkcore.com/migrations?
// dotnet add package Migrations --version 6.0.0