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
using WeatherCommon.Classes;
using Microsoft.WindowsAzure.Storage.Table;

namespace WeatherWorkerRoleData.Classes
{
    public class WindGeneratorBase : TableEntity
    {
        static AggregateRepository aggregateRepository = new AggregateRepository();
        static WindMillRepository windMillRepository = new WindMillRepository();

        private string weather;
        private string windMill;
        private int windMillCnt;
        private string aggregate;
        private double aggregatePower;
        private double power;
        private int aggregateONCnt;



        public WindGeneratorBase()
        {

        }



        public WindGeneratorBase(string weather, string windMill, int windMillCnt, string aggregate)
        {
            PartitionKey = "WindGenerator";
            RowKey = weather;
            this.weather = weather;
            this.windMill = windMill;
            this.windMillCnt = windMillCnt;
            this.aggregatePower = aggregateRepository.GetOneAggregate(aggregate).Power * windMillCnt;
            this.aggregate = aggregate;
            
            WindMillBase w = windMillRepository.GetOneWindMill(windMill);
            if(w.MinPower < 12000)
                w.MinPower *= windMillCnt;
            windMillRepository.AddOrReplaceWindMill(w);

        }

        public string Weather { get => weather; set => weather = value; }
        public string WindMill { get => windMill; set => windMill = value; }
        public int WindMillCnt { get => windMillCnt; set => windMillCnt = value; }
        public string Aggregate { get => aggregate; set => aggregate = value; }
        public double Power { get => CalculatePower(); set => power = value; }
        public double AggregatePower { get => aggregatePower; set => aggregatePower = value; }
        public int AggregateONCnt { get => aggregateONCnt; set => aggregateONCnt = value; }

        public double CalculatePower()
        {

            WeatherBase weatherBase = new WeatherRepository().GetLastWeather(Weather);
            WindMillBase windMillBase = new WindMillRepository().GetOneWindMill(WindMill);
            WeatherRepository weatherRepository = new WeatherRepository();
            double power = 0;

            if (weatherBase.WindSpeed >= windMillBase.MaxSpeed && windMillBase.WorkingTime >= windMillBase.MaxSpeedTime)
            {
                power = 0;

            }
            else if (weatherBase.WindSpeed >= windMillBase.MaxSpeed && windMillBase.WorkingTime < windMillBase.MaxSpeedTime)
            {
                power = 0.5 * windMillBase.Coefficient * weatherBase.AirDensity * CalculateSurfaceArea(windMillBase) * Math.Pow(weatherBase.WindSpeed, 3);
                windMillBase.WorkingTime++;
            }
            else
            {
                power = 0.5 * windMillBase.Coefficient * weatherBase.AirDensity * CalculateSurfaceArea(windMillBase) * Math.Pow(weatherBase.WindSpeed, 3);
                windMillBase.WorkingTime = 0;
            }

            if (windMillBase.WorkingTime == windMillBase.MaxSpeedTime + (windMillBase.MaxSpeedTime / 2)) // cooling period
            {
                windMillBase.WorkingTime = 0;
            }
            return power*windMillCnt;
        }
        public double CalculateSurfaceArea(WindMillBase windMillBase)
        {
            return Math.Pow((windMillBase.TurbineDiameter / 2), 2) * Math.PI;
        }
    }//end Weather

}//end namespace WeatherWorkerRoleData