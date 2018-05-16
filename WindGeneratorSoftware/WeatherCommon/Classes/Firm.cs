///////////////////////////////////////////////////////////
//  Firm.cs
//  Implementation of the Class Firm
//  Generated by Enterprise Architect
//  Created on:      16-maj-2018 10.33.05
//  Original author: Stefan
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace WeatherCommon.Classes
{
	public class Firm {

		private Aggregate aggregate;
		private string Name;
		private WindGenerator windGenerator;
		private int windmillCount;

		public Firm(){

		}

        public Firm(Aggregate aggregate, string name, WindGenerator windGenerator, int windmillCount)
        {
            this.Aggregate = aggregate;
            Name1 = name;
            this.WindGenerator = windGenerator;
            this.WindmillCount = windmillCount;
        }

        public Aggregate Aggregate { get => aggregate; set => aggregate = value; }
        public string Name1 { get => Name; set => Name = value; }
        public WindGenerator WindGenerator { get => windGenerator; set => windGenerator = value; }
        public int WindmillCount { get => windmillCount; set => windmillCount = value; }
    }//end Firm

}//end namespace WeatherCommon