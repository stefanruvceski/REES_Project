using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWorkerRoleData.Classes
{
    public class WindMillBase : TableEntity
    {
        private static int id = 0;
        private double coefficient;
        private double minPower;
        private double turbineDiameter;
        private double maxSpeed;
        private int maxSpeedTime;
        private int workingTime = 0;

        public WindMillBase()
        {

        }

        public WindMillBase(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime)
        {
            // validacija parametara konstruktora
            if (coefficient < 0.25 || coefficient > 0.45)
            {
                throw new ArgumentException("Coefficient must be in range [0.25, 0.45].");
            }

            if (minPower <= 0)
            {
                throw new ArgumentException("Minimum power of windmill must be greater than 0.");
            }

            if (turbineDiameter <= 0)
            {
                throw new ArgumentException("Turbine diameter must be greater than 0.");
            }

            if (maxSpeed < 0 || maxSpeed > 80)
            {
                throw new ArgumentException("Maximum wind speed must be in range [0, 80] m/s.");
            }

            if (maxSpeedTime <= 0)
            {
                throw new ArgumentException("Turbine working time on maximim speed must be greater than 0.");
            }

            PartitionKey = "WindMill";
            RowKey = (++Id).ToString();
            this.coefficient = coefficient;
            this.minPower = minPower;
            this.turbineDiameter = turbineDiameter;
            this.maxSpeed = maxSpeed;
            this.maxSpeedTime = maxSpeedTime;
        }

        public double Coefficient { get => coefficient; set => coefficient = value; }
        public double MinPower { get => minPower; set => minPower = value; }
        public double TurbineDiameter { get => turbineDiameter; set => turbineDiameter = value; }
        public double MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public int MaxSpeedTime { get => maxSpeedTime; set => maxSpeedTime = value; }
        public int WorkingTime { get => workingTime; set => workingTime = value; }
        public static int Id { get => id; set => id = value; }
    }
}

