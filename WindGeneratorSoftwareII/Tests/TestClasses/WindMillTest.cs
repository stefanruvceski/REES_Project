using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCommon.Classes;

namespace Tests.TestClasses
{
    [TestFixture]
    public class WindMillTest
    {
        // testovima su pokriveni svih 5 modela vetrenjace u ponudi
        [Test]
        [TestCase(0.30, 1000, 20, 5, 10, 5)]
        [TestCase(0.35, 1500, 30, 5, 10, 5)]
        [TestCase(0.35, 2000, 35, 8, 10, 5)]
        [TestCase(0.35, 12000, 40, 10, 10, 5)]
        [TestCase(0.40, 20000, 45, 18, 10, 5)]
        public void WindMillConstructor_GoodParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime, int workingTime)
        {
            WindMill windMill = new WindMill(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime, workingTime);

            Assert.AreEqual(windMill.Coefficient, coefficient);
            Assert.AreEqual(windMill.MinPower, minPower);
            Assert.AreEqual(windMill.TurbineDiameter, turbineDiameter);
            Assert.AreEqual(windMill.MaxSpeed, maxSpeed);
            Assert.AreEqual(windMill.MaxSpeedTime, maxSpeedTime);
        }

        [Test]
        [TestCase(0.25, 0.1, 0.1, 0.1, 1, 5)]
        [TestCase(0.25, 0.1, 0.1, 80, 1, 5)]
        [TestCase(0.45, 0.1, 0.1, 0.1, 1, 5)]
        [TestCase(0.45, 0.1, 0.1, 80, 1, 5)]
        public void WindMillConstructor_BorderParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime, int workingTime)
        {
            WindMill windMill = new WindMill(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime, workingTime);

            Assert.AreEqual(windMill.Coefficient, coefficient);
            Assert.AreEqual(windMill.MinPower, minPower);
            Assert.AreEqual(windMill.TurbineDiameter, turbineDiameter);
            Assert.AreEqual(windMill.MaxSpeed, maxSpeed);
            Assert.AreEqual(windMill.MaxSpeedTime, maxSpeedTime);
        }

        [Test]
        [TestCase(0.20, 1000, 20, 5, 10, 5)]
        [TestCase(0.30, 0, 20, 5, 10, 5)]
        [TestCase(0.30, 1000, 0, 5, 10, 5)]
        [TestCase(0.30, 1000, 20, -0.1, 10, 5)]
        [TestCase(0.30, 1000, 20, 81, 10, 5)]
        [TestCase(0.30, 1000, 20, 5, 0, 5)]
        [ExpectedException(typeof(ArgumentException))]          // ako ostavim ovo, svi testovi treba da prodju, jer svi treba da bace ovaj exception
        public void WindMillConstructor_BadParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime, int workingTime)
        {
            WindMill windMill = new WindMill(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime, workingTime);
        }
    }
}
