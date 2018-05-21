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
        static int id = 0;
        private double airDensity = 1.29;
        private string city;
        private string description;
        private double maxTemp;
        private double minTemp;
        private double pressure;
        private double windSpeed;

        public double AirDensity { get => airDensity; set => airDensity = value; }
        public string City { get => city; set => city = value; }
        public string Description { get => description; set => description = value; }
        public double MaxTemp { get => maxTemp; set => maxTemp = value; }
        public double MinTemp { get => minTemp; set => minTemp = value; }
        public double Pressure { get => pressure; set => pressure = value; }
        public double WindSpeed { get => windSpeed; set => windSpeed = value; }

        public WeatherBase()
        {

        }

        public WeatherBase(Weather w)
        {
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
