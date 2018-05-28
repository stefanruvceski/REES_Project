using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherWorkerRoleData.Classes;

namespace Tests.BaseTestClasses
{
    [TestFixture]
    public class AggregateBaseTest
    {
        [Test]
        [TestCase(10, 10000, true)]
        [TestCase(20, 20000, false)]
        [TestCase(30, 30000, true)]
        public void AggregateBaseConstructor_GoodParameters(double costPerKw, double power, bool state)
        {
            AggregateBase aggregate = new AggregateBase(costPerKw, power, state);

            Assert.AreEqual(aggregate.CostPerKw, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }
    
        [Test]
        [TestCase(0.1, 0.1, true)]
        [TestCase(0.0001, 0.0001, false)]
        public void AggregateBaseConstructor_BorderParameters(double costPerKw, double power, bool state)
        {
            AggregateBase aggregate = new AggregateBase(costPerKw, power, state);

            Assert.AreEqual(aggregate.CostPerKw, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }

        [Test]
        [TestCase(0, 10000, true)]
        [TestCase(10, 0, true)]
        [ExpectedException(typeof(ArgumentException))]
        public void AggregateBaseConstructor_BadParameters(double costPerKw, double power, bool state)
        {
            AggregateBase aggregate = new AggregateBase(costPerKw, power, state);

            Assert.AreEqual(aggregate.CostPerKw, costPerKw);
            Assert.AreEqual(aggregate.Power, power);
            Assert.AreEqual(aggregate.State, state);
        }
    }
}
