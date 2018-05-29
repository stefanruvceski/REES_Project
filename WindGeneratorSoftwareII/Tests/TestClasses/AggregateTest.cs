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
    public class AggregateTest
    {
        [Test]
        [TestCase(1, 10, 500, true)]
        [TestCase(2, 12, 1000, true)]
        [TestCase(3, 15, 1500, false)]
        public void AggregateConstructor_GoodParameters(int id, double costPerKw, double power, bool state)
        {
            Aggregate aggregate = new Aggregate(id, costPerKw, power, state);

            Assert.AreEqual(aggregate.Id, id);
            Assert.AreEqual(aggregate.CostPerHour, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }

        [Test]
        [TestCase(0, 0.1, 0.1, true)]
        public void AggregateConstructor_BorderParameters(int id, double costPerKw, double power, bool state)
        {
            Aggregate aggregate = new Aggregate(id, costPerKw, power, state);

            Assert.AreEqual(aggregate.Id, id);
            Assert.AreEqual(aggregate.CostPerHour, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }

        [Test]
        [TestCase(-1, 10, 500, true)]
        [TestCase(0, 0, 500, true)]
        [TestCase(0, 10, 0, true)]
        [ExpectedException(typeof(ArgumentException))]
        public void AggregateConstructor_BadParameters(int id, double costPerKw, double power, bool state)
        {
            Aggregate aggregate = new Aggregate(id, costPerKw, power, state);

            Assert.AreEqual(aggregate.Id, id);
            Assert.AreEqual(aggregate.CostPerHour, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }
    }
}
