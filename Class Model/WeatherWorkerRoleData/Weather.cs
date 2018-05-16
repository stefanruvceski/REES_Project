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



namespace Project.WeatherCloudService.WeatherWorkerRoleData {
	public class Weather {

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

		~Weather(){

		}

	}//end Weather

}//end namespace WeatherWorkerRoleData