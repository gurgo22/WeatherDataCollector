using Newtonsoft.Json.Linq;

namespace WeatherDataCollector {

    //CLASS TO GET WEATHER DATA FROM OpenWeatherAPI
    internal class APIWeatherSource : IWeatherDataSource {

        public WeatherData SendWeatherData () {

            return CreateWeatherData();
        }

        //GETS THE CURRENT WEATHER THROUGH THE API
        public string GetCurrentWeatherData () {

            HttpClient client = new HttpClient();

            string cityName = "Budapest";
            
            string apiKey = "cdaaf44170dad0a7d8b66513db2f0a9d";

            string userURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            //THE RESPONSE ARRIVES IN JSON FORMAT
            string? weatherResponse = client.GetStringAsync(userURL).Result;

            return weatherResponse;
        }

        //CREATES WeatherData FROM THE JSON
        public WeatherData CreateWeatherData () {   //OUT

            string weatherDataText = GetCurrentWeatherData();

            JObject responseJson = JObject.Parse(weatherDataText);
            /*
            foreach (JToken property in responseJson.Properties()) {

                Console.WriteLine(property);
            }*/
            
            //RESPONSE JSON FILE IS NESTED
            string description = responseJson["weather"]?[0]?["description"]?.ToString();

            double temperature = Convert.ToDouble(responseJson["main"]?["temp"]);

            WeatherData newWeatherData = new WeatherData(temperature, description);

            return newWeatherData;
        }
    }
}
