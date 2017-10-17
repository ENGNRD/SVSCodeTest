using Name;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1; 

namespace AvgTempTestCon
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData[] weatherReadings = UnitTestWeatherAggService.GetBasicData();

            WeatherService weatherAggSrvc = new WeatherService();
            IEnumerable<CityAveragedWeatherData> aggWeatherData = weatherAggSrvc.AggregateWeatherData(weatherReadings);
            foreach (CityAveragedWeatherData aggItem in aggWeatherData)
            {
                Console.WriteLine("Location: {0}, {1}. Year: {2}. Month: {3}. Avg High:{4} Degrees. Avg Low {5} Degrees.", aggItem.City, aggItem.State, aggItem.Year, aggItem.Month, aggItem.AverageHighTemp, aggItem.AverageLowTemp);
            }

            
        }

        
    }
}
