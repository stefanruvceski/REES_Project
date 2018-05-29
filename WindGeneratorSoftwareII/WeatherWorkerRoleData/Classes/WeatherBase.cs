using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCommon.Classes;

namespace WeatherWorkerRoleData.Classes
{
    public class WeatherBase : TableEntity
    {
        #region parameters
        static int id = 0;
        private double airDensity = 1.29;
        private string city;
        private string description;
        private double maxTemp;
        private double minTemp;
        private double pressure;
        private double windSpeed;
        #endregion

        #region property
        public double AirDensity { get => airDensity; set => airDensity = value; }
        public string City { get => city; set => city = value; }
        public string Description { get => description; set => description = value; }
        public double MaxTemp { get => maxTemp; set => maxTemp = value; }
        public double MinTemp { get => minTemp; set => minTemp = value; }
        public double Pressure { get => pressure; set => pressure = value; }
        public double WindSpeed { get => windSpeed; set => windSpeed = value; }
        #endregion

        public WeatherBase()
        {

        }

        public WeatherBase(Weather w)
        {
            if(w == null)
            {
                throw new ArgumentNullException("Argument can't be null.");
            }

            PartitionKey = "Weather";
            RowKey = (++id).ToString();

            this.city = w.City;
            this.description = w.Description;
            this.maxTemp = w.MaxTemp;
            this.minTemp = w.MinTemp;
            this.pressure = w.Pressure;
            this.windSpeed = w.WindSpeed;
        }

        public WeatherBase(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            if (city == null || description == null)
            {
                throw new ArgumentNullException("Arguments can't be null.");
            }

            if (city.Equals(String.Empty))
            {
                throw new ArgumentException("Empty city name.");
            }

            if (description.Equals(String.Empty))
            {
                throw new ArgumentException("Empty weather description.");
            }

            if (maxTemp > 65 || maxTemp < -90 || minTemp > 65 || minTemp < -90)
            {
                throw new ArgumentOutOfRangeException("Temperatures must be in range [-90, +65] Celsius degrees.");
            }

            if (minTemp > maxTemp)
            {
                throw new ArgumentException("Minimum temperature can't be greater than maximum temperature.");
            }

            if (pressure < 800 || pressure > 1100)
            {
                throw new ArgumentOutOfRangeException("Air pressure must be in range [800, 1000] milibars.");
            }

            if (windSpeed < 0 || windSpeed > 80)
            {
                throw new ArgumentOutOfRangeException("Wind speed must be in range [0, 80] m/s.");
            }

            PartitionKey = "Weather";
            RowKey = (++id).ToString();

            this.city = city;
            this.description = description;
            this.maxTemp = maxTemp;
            this.minTemp = minTemp;
            this.pressure = pressure;
            this.windSpeed = windSpeed;
        }
    }
}
