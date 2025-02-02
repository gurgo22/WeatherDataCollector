using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataCollector {

    //SERVICE CLASS THAT HANDLES INSERTION INTO THE DATABASE
    internal class DatabaseService {

        private readonly ApplicationDbContext _context;

        public DatabaseService(ApplicationDbContext context) {

            this._context = context;
        }

        //INSERTS DATA INTO THE DATABASE
        public void SaveWeatherData (WeatherData data) {

            try {

                _context.Weather.Add(data); 
                _context.SaveChanges();
            }
            catch (Exception exception) {

                Console.WriteLine($"Error while inserting data:" + exception.Message);
            }
        }    
    }
}
