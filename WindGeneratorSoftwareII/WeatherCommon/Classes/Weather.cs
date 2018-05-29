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
        #region parameters
        private double airDensity = 1.29;
        private string city;
        private string description;
        private double maxTemp;
        private double minTemp;
        private double pressure;
        private double windSpeed;
        #endregion
        public Weather()
        {

        }

        public Weather(string city)
        {
            if(city == null)
            {
                throw new ArgumentNullException("Arguments can't be null.");
            }

            if (city.Equals(String.Empty))
            {
                throw new ArgumentException("Empty city name.");
            }

            this.city = city;
        }

        public Weather(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            if(city == null || description == null)
            {
                throw new ArgumentNullException("Arguments can't be null.");
            }

            if(city.Equals(String.Empty))
            {
                throw new ArgumentException("Empty city name.");
            }

            if (description.Equals(String.Empty))
            {
                throw new ArgumentException("Empty weather description.");
            }

            if(maxTemp > 65 || maxTemp < -90 || minTemp > 65 || minTemp < -90)
            {
                throw new ArgumentOutOfRangeException("Temperatures must be in range [-90, +65] Celsius degrees.");
            }

            if(minTemp > maxTemp)
            {
                throw new ArgumentException("Minimum temperature can't be greater than maximum temperature.");
            }

            if(pressure < 800 || pressure > 1100)
            {
                throw new ArgumentOutOfRangeException("Air pressure must be in range [800, 1000] milibars.");
            }

            if(windSpeed < 0 || windSpeed > 80)
            {
                throw new ArgumentOutOfRangeException("Wind speed must be in range [0, 80] m/s.");
            }

            this.City = city;
            this.Description = description;
            this.MaxTemp = maxTemp;
            this.MinTemp = minTemp;
            this.Pressure = pressure;
            this.WindSpeed = windSpeed;
            this.AirDensity = 1.29;
        }
        #region property
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
        public double WindSpeed { get => Math.Round(windSpeed, 3); set => windSpeed = value; }
        #endregion

        public override string ToString()
        {
            string retVal = String.Format($"City: {City}\nair density: {AirDensity}\nmax temperature: {MaxTemp}\nmin temperature: {MinTemp}\npressure: {Pressure}\nwind speed: {WindSpeed}\n");
            retVal += "---------------------------------";

            return retVal;
        }
    }
}
