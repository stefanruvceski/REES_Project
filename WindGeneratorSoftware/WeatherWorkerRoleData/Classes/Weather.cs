///////////////////////////////////////////////////////////
//  Weather.cs
//  Implementation of the Class Weather
//  Generated by Enterprise Architect
//  Created on:      16-maj-2018 10.31.48
//  Original author: Stefan
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace WeatherWorkerRoleData.Classes
{
	public class Weather  { // :TableEntity

		private double airDensity = 1.29;
		private string city;
		private string description;
		private double maxTem;
		private double minTemp;
		private double pressure;
		private int windAngle;
		private double windSpeed;

		public Weather(){

		}

        public Weather(string city, string description, double maxTem, double minTemp, double pressure, int windAngle, double windSpeed)
        {
            this.City = city;
            this.Description = description;
            this.MaxTem = maxTem;
            this.MinTemp = minTemp;
            this.Pressure = pressure;
            this.WindAngle = windAngle;
            this.WindSpeed = windSpeed;
            this.AirDensity = 1.29;
        }

        public double AirDensity { get => airDensity; set => airDensity = value; }
        public string City { get => city; set => city = value; }
        public string Description { get => description; set => description = value; }
        public double MaxTem { get => maxTem; set => maxTem = value; }
        public double MinTemp { get => minTemp; set => minTemp = value; }
        public double Pressure { get => pressure; set => pressure = value; }
        public int WindAngle { get => windAngle; set => windAngle = value; }
        public double WindSpeed { get => windSpeed; set => windSpeed = value; }
    }//end Weather

}//end namespace WeatherWorkerRoleData