using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataCollector {
    internal class WeatherData {

        public WeatherData(double Temperature, string Description) { 
        
            this.Temperature = Temperature;
            this.Description = Description;
        }

        public int Id { get; private set; } //FOR DATABASE OPERATIONS ONLY
        public double Temperature { get; private set; }
        public string Description { get; private set; }
    }
}
