using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace WeatherDataCollector {
    internal class Program {
        static void Main(string[] args) {

            //REGISTERING DEPENDENCIES
            //WITH DEPENDENCY INJECTION, THE WEATHER DATA SOURCE CAN BE EASILY SWAPPED
            ServiceProvider services = new ServiceCollection()
            //.AddScoped<IWeatherDataSource, APIWeatherSource>()
            .AddScoped<IWeatherDataSource, FileWeatherSource>()
            .AddDbContext<ApplicationDbContext>()
            .AddScoped<DatabaseService>()
            .BuildServiceProvider();

            var weatherSource = services.GetRequiredService<IWeatherDataSource>();
            var databaseService = services.GetRequiredService<DatabaseService>();

            WeatherData data = weatherSource.SendWeatherData();
            Console.WriteLine("Received weather data: " + data.Temperature + " " + data.Description);

            databaseService.SaveWeatherData(data);


            //BAD PRACTICE - MANUAL DEPENDENCY MANAGEMENT
            /*ApplicationDbContext context = new ApplicationDbContext();

            IWeatherDataSource apiTest = new APIWeatherSource();

            WeatherData apiData = apiTest.SendWeatherData();

            IWeatherDataSource xmlTest = new FileWeatherSource();

            WeatherData xmlData = xmlTest.SendWeatherData();

            Console.WriteLine(apiData.Temperature + " " + apiData.Description);

            DatabaseService databaseHandler = new DatabaseService(context);

            databaseHandler.SaveWeatherData(apiData);
            databaseHandler.SaveWeatherData(xmlData);*/
        }
    }
}