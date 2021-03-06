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
        #region parameters
        private static int id = 0;
        private double costPerHour;
        private double power;
        private bool state;
        #endregion

        #region property
        public double CostPerHour { get => costPerHour; set => costPerHour = value; }
        public double Power { get => power; set => power = value; }
        public bool State { get => state; set => state = value; }
        #endregion

        public AggregateBase()
        {

        }

        public AggregateBase(double costPerHour, double power, bool state)
        {
            if (costPerHour <= 0)
            {
                throw new ArgumentException("Price for kW must be greater than 0.");
            }

            if (power <= 0)
            {
                throw new ArgumentException("Aggregate power must be greater than 0.");
            }

            PartitionKey = "Aggregate";
            RowKey = (++id).ToString();
            id = int.Parse(RowKey);

            this.costPerHour = costPerHour;
            this.power = power;
            this.state = state;
        }
    }
}
