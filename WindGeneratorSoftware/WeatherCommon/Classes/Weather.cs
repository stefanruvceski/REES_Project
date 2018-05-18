using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCommon.Classes
{
    [DataContract]
    public class Weather
    {
        private double airDensity = 1.29;
        private string city;
        private string description;
        private double maxTemp;
        private double minTemp;
        private double pressure;
        private int windAngle;
        private double windSpeed;

        public Weather()
        {

        }

        public Weather(string city, string description, double maxTemp, double minTemp, double pressure, int windAngle, double windSpeed)
        {
            this.City = city;
            this.Description = description;
            this.MaxTemp = maxTemp;
            this.MinTemp = minTemp;
            this.Pressure = pressure;
            this.WindAngle = windAngle;
            this.WindSpeed = windSpeed;
            this.AirDensity = 1.29;
        }

        [DataMember]
        public double AirDensity { get => airDensity; set => airDensity = value; }
        [DataMember]
        public string City { get => city; set => city = value; }
        [DataMember]
        public string Description { get => description; set => description = value; }
        [DataMember]
        public double MaxTemp { get => maxTemp; set => maxTemp = value; }
        [DataMember]
        public double MinTemp { get => minTemp; set => minTemp = value; }
        [DataMember]
        public double Pressure { get => pressure; set => pressure = value; }
        [DataMember]
        public int WindAngle { get => windAngle; set => windAngle = value; }
        [DataMember]
        public double WindSpeed { get => windSpeed; set => windSpeed = value; }
    }
}
