using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace WeatherDataCollector {

    //CLASS TO GET WEATHER DATA FROM XML FILE
    internal class FileWeatherSource : IWeatherDataSource {

        //RETURNS THE DATA IF THE FILE CAN BE READ
        //OTHERWISE IT RETURNS A DEFAULT VALUE
        public WeatherData SendWeatherData() {

            if (ReadXMLFile (out XmlDocument xmlFile)) {
                
                return CreateWeatherData(xmlFile);
            
            } else {
            
                return new WeatherData(999, "NA");
            }
        }

        //TRIES TO READ THE XML FILE AND IF POSSIBLE RETURNS IT
        public bool ReadXMLFile (out XmlDocument xmlFile) {

            xmlFile = null;

            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string folderPath = Path.Combine(projectDirectory, "Data");
            string filePath = Path.Combine(folderPath, "Weather_Data_File.xml");

            if (File.Exists(filePath)) {

                try {

                    xmlFile = new XmlDocument();
                    xmlFile.Load(filePath);

                    Console.WriteLine(xmlFile.OuterXml);

                    return true;

                }
                catch (Exception exception){

                    Console.WriteLine("Error while loading XML file: " + exception.Message);
                    return false;
                }
            }
            else {
                
                Console.WriteLine("XML file not found at: " + filePath + " this path!");
                return false;
            }
        }

        //CREATES WeatherData FROM AN XML FILE
        public WeatherData CreateWeatherData (XmlDocument xmlFile) {

            string description = xmlFile.DocumentElement["Description"].InnerText;
            double temperature = Convert.ToDouble(xmlFile.DocumentElement["Temperature"].InnerText);

            WeatherData newWeatherData = new WeatherData(temperature, description);

            return newWeatherData;
        }
    }
}
