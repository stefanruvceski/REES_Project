using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherCommon.Classes;
using WeatherWorkerRoleData.Classes;

namespace Tests.BaseTestClasses
{
    [TestFixture]
    public class WindMillBaseTest
    {
        [Test]
        [TestCase(0.30, 1000, 20, 5, 10)]
        [TestCase(0.35, 1500, 30, 5, 10)]
        [TestCase(0.35, 2000, 35, 8, 10)]
        [TestCase(0.35, 12000, 40, 10, 10)]
        [TestCase(0.40, 20000, 45, 18, 10)]
        public void WindMillBaseConstructor_GoodParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime)
        {
            WindMillBase windMill = new WindMillBase(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime);

            Assert.AreEqual(windMill.Coefficient, coefficient);
            Assert.AreEqual(windMill.MinPower, minPower);
            Assert.AreEqual(windMill.TurbineDiameter, turbineDiameter);
            Assert.AreEqual(windMill.MaxSpeed, maxSpeed);
            Assert.AreEqual(windMill.MaxSpeedTime, maxSpeedTime);
        }

        [Test]
        [TestCase(0.25, 0.1, 0.1, 0.1, 1)]
        [TestCase(0.25, 0.1, 0.1, 80, 1)]
        [TestCase(0.45, 0.1, 0.1, 0.1, 1)]
        [TestCase(0.45, 0.1, 0.1, 80, 1)]
        public void WindMillBaseConstructor_BorderParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime)
        {
            WindMillBase windMill = new WindMillBase(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime);

            Assert.AreEqual(windMill.Coefficient, coefficient);
            Assert.AreEqual(windMill.MinPower, minPower);
            Assert.AreEqual(windMill.TurbineDiameter, turbineDiameter);
            Assert.AreEqual(windMill.MaxSpeed, maxSpeed);
            Assert.AreEqual(windMill.MaxSpeedTime, maxSpeedTime);
        }

        [Test]
        [TestCase(0.20, 1000, 20, 5, 10)]
        [TestCase(0.30, 0, 20, 5, 10)]
        [TestCase(0.30, 1000, 0, 5, 10)]
        [TestCase(0.30, 1000, 20, -0.1, 10)]
        [TestCase(0.30, 1000, 20, 81, 10)]
        [TestCase(0.30, 1000, 20, 5, 0)]
        [ExpectedException(typeof(ArgumentException))]         
        public void WindMillBaseConstructor_BadParameters(double coefficient, double minPower, double turbineDiameter, double maxSpeed, int maxSpeedTime)
        {
            WindMillBase windMill = new WindMillBase(coefficient, minPower, turbineDiameter, maxSpeed, maxSpeedTime);

            Assert.AreEqual(windMill.Coefficient, coefficient);
            Assert.AreEqual(windMill.MinPower, minPower);
            Assert.AreEqual(windMill.TurbineDiameter, turbineDiameter);
            Assert.AreEqual(windMill.MaxSpeed, maxSpeed);
            Assert.AreEqual(windMill.MaxSpeedTime, maxSpeedTime);
        }
    }
}
