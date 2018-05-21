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

