using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Name;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestWeatherAggService
    {
        [TestMethod]
        public void tmBasicTest()
        {
            WeatherData[] weatherReadings = UnitTestWeatherAggService.GetBasicData();

            WeatherService weatherAggSrvc = new WeatherService();
            IEnumerable<CityAveragedWeatherData> aggWeatherData = weatherAggSrvc.AggregateWeatherData(weatherReadings);
            foreach (CityAveragedWeatherData aggItem in aggWeatherData)
            {
                Assert.IsInstanceOfType(aggItem, typeof(CityAveragedWeatherData));
                Assert.IsNotNull(aggItem.AverageHighTemp);
                Assert.IsNotNull(aggItem.AverageLowTemp);
            }

        }


        public static WeatherData[] GetBasicData()
        {
            WeatherData[] weatherReadings = new WeatherData[10];


            weatherReadings[0] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[1] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now.AddMonths(-1),
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[2] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[3] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now.AddMonths(-1),
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[4] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[5] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now.AddMonths(-1),
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[6] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[7] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now.AddMonths(-1),
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[8] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now,
                HighTemp = 100,
                LowTemp = 40
            };

            weatherReadings[9] = new WeatherData()
            {
                City = "Boulder",
                State = "CO",
                Date = DateTime.Now.AddMonths(-1),
                HighTemp = 100,
                LowTemp = 40
            };

            return weatherReadings;
        }
    }
}
