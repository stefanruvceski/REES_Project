///////////////////////////////////////////////////////////
//  Aggregate.cs
//  Implementation of the Class Aggregate
//  Generated by Enterprise Architect
//  Created on:      16-maj-2018 10.33.04
//  Original author: Stefan
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace WeatherCommon.Classes {
	public class Aggregate {

		private double costPerKw;
		private double power;
		private bool state;

		public Aggregate(){

		}

        public Aggregate(double costPerKw, double power, bool state)
        {
            this.CostPerKw = costPerKw;
            this.Power = power;
            this.State = state;
        }

        public double CostPerKw { get => costPerKw; set => costPerKw = value; }
        public double Power { get => power; set => power = value; }
        public bool State { get => state; set => state = value; }
    }//end Aggregate

}//end namespace WeatherCommon