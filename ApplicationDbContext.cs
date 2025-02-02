using Microsoft.EntityFrameworkCore;

namespace WeatherDataCollector {
    internal class ApplicationDbContext : DbContext {

        public DbSet<WeatherData> Weather { get; set; }
            
        //CONFIG METHOD MUST BE OVERWRITTEN IN ORDER TO SET DATABASE SOURCE
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WeatherDatabase;Integrated Security=True;");
        }

        //NOTE ON HOW TO SET UP DATABASE IN PACKAGE MANAGER
        //dotnet add package Microsoft.EntityFrameworkCore
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update
    }
}
