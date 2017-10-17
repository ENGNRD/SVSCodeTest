using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Name
{
    //We are compiling a report on the average temperatures among various cities over each month. 
    //We receive individual daily data points from a weather service. 
    //Given a collection of data points over a given month, average the data into the requested format for easier reporting.

    //Please include tests in the testing framework you are most comfortable with.

    //We prefer your completed work in a Git repo.

    public class WeatherService
    {
        public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
        {
            AggregatedWeatherData aggWeatherData = new AggregatedWeatherData(inputData);
            return (IEnumerable<CityAveragedWeatherData>)aggWeatherData.Values;
        }
    }

    public class WeatherData
    {
        internal string DataPointKey 
        {
            get
            {
                return City.Trim() + State.Trim() + Date.Year.ToString() + Date.Month.ToString();
            }
        }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
    }

    public class CityAveragedWeatherData
    {
        private List<decimal> _highTempList = new List<decimal>();
        private List<decimal> _lowTempList = new List<decimal>();
        
        public CityAveragedWeatherData(string city, string state, int dateYear, int dateMonth)
        {
            City = city;
            State = state;
            Year = dateYear;
            Month = dateMonth;
        }

        public int Month { get; set; }
        public int Year { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        
        public decimal AverageHighTemp 
        {
            get
            {
                return _highTempList.Average();
            }
        }

        public decimal AverageLowTemp 
        {
            get
            {
                return _lowTempList.Average();
            }
        }
        
        internal string CityState
        {
            get
            {
                return City.Trim() + State.Trim();
            }
        }

        internal void AddRawDataPoint(WeatherData dataPoint)
        {
            _highTempList.Add(dataPoint.HighTemp);
            _lowTempList.Add(dataPoint.LowTemp);
        }

    }

    public class AggregatedWeatherData : SortedList<string, CityAveragedWeatherData>
    {
        public AggregatedWeatherData()
        {
        }

        public AggregatedWeatherData(WeatherData[] inputData)
        {
            this.LoadData(inputData);
        }

        public void LoadData(WeatherData[] inputData)
        {
            foreach(WeatherData dataPoint in inputData)
            {
                CityAveragedWeatherData currentItem = null;
                
                if (this.IndexOfKey(dataPoint.DataPointKey) >= 0)
                {
                    currentItem = this[dataPoint.DataPointKey];
                }
                else
                {
                    currentItem = new CityAveragedWeatherData(dataPoint.City.Trim(), dataPoint.State.Trim(), dataPoint.Date.Year, dataPoint.Date.Month);
                    this.Add(dataPoint.DataPointKey, currentItem);
                }

                currentItem.AddRawDataPoint(dataPoint);

            }
        }

        
    }
}
