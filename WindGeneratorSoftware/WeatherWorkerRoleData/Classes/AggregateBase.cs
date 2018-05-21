﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWorkerRoleData.Classes
{
    public class AggregateBase : TableEntity
    {
        private static int id = 0;
        private double costPerKw;
        private double power;
        private bool state;

      
        public double CostPerKw { get => costPerKw; set => costPerKw = value; }
        public double Power { get => power; set => power = value; }
        public bool State { get => state; set => state = value; }

        public AggregateBase()
        {
            
        }

        public AggregateBase(double costPerKw, double power, bool state)
        {
            PartitionKey = "Aggregate";
            RowKey = (++id).ToString();
            id = int.Parse(RowKey);

            this.costPerKw = costPerKw;
            this.power = power;
            this.state = state;
        }
    }
}