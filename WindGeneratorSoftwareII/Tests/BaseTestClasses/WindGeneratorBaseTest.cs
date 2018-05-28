using Moq;
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
    class WindGeneratorBaseTest
    {
        Mock<WindMillBase> windMillBaseMock;
        Mock<WindGeneratorBase> windGeneratorBaseMock;

        [SetUp]
        public void SetUp()
        {
            windMillBaseMock = new Mock<WindMillBase>();
            windGeneratorBaseMock = new Mock<WindGeneratorBase>();
        }

        // mislim da je problem  pristup bazi koji se izvrsava unutar konstruktora
        /*[Test]
        [TestCase("1", "1", 10, "1")]
        [TestCase("2", "2", 10, "2")]
        [TestCase("3", "3", 10, "3")]
        public void WindGeneratorBaseConstructor_GoodParameters(string weather, string windMill, int windMillCnt, string aggregate)
        {
            WindGeneratorBase windGenerator = new WindGeneratorBase(weather, windMill, windMillCnt, aggregate);

            Assert.AreEqual(windGenerator.Weather, weather);
            Assert.AreEqual(windGenerator.WindMill, windMill);
            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
            Assert.AreEqual(windGenerator.Aggregate, aggregate);
        }*/

        [Test]
        [TestCase(null, "1", 10, "1")]
        [TestCase("2", null, 10, "2")]
        [TestCase("3", "3", 10, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindGeneratorBaseConstructor_BadParameters1(string weather, string windMill, int windMillCnt, string aggregate)
        {
            WindGeneratorBase windGenerator = new WindGeneratorBase(weather, windMill, windMillCnt, aggregate);

            Assert.AreEqual(windGenerator.Weather, weather);
            Assert.AreEqual(windGenerator.WindMill, windMill);
            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
            Assert.AreEqual(windGenerator.Aggregate, aggregate);
        }

        [Test]
        [TestCase("1", "1", 0, "1")]
        [TestCase("1", "1", -1, "1")]
        [ExpectedException(typeof(ArgumentException))]
        public void WindGeneratorBaseConstructor_BadParameters2(string weather, string windMill, int windMillCnt, string aggregate)
        {
            WindGeneratorBase windGenerator = new WindGeneratorBase(weather, windMill, windMillCnt, aggregate);

            Assert.AreEqual(windGenerator.Weather, weather);
            Assert.AreEqual(windGenerator.WindMill, windMill);
            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
            Assert.AreEqual(windGenerator.Aggregate, aggregate);
        }

        [Test]
        [TestCase(10, ExpectedResult = 5 * 5 * Math.PI)]
        [TestCase(30, ExpectedResult = 15 * 15 * Math.PI)]
        [TestCase(50, ExpectedResult = 25 * 25 * Math.PI)]
        public double CalculateSurfaceArea_GoodTest(double diameter)
        {
            windMillBaseMock.Object.TurbineDiameter = diameter;                 // setovanje polja TurbineDiameter windMillMock-a
            double area = windGeneratorBaseMock.Object.CalculateSurfaceArea(windMillBaseMock.Object);

            return area;
        }

        [Test]
        [TestCase(0, ExpectedResult = 5 * 5 * Math.PI)]
        [TestCase(-5, ExpectedResult = 15 * 15 * Math.PI)]
        [ExpectedException(typeof(ArgumentException))]
        public double CalculateSurfaceArea_BadTest1(double diameter)
        {
            windMillBaseMock.Object.TurbineDiameter = diameter;                 // setovanje polja TurbineDiameter windMillMock-a
            double area = windGeneratorBaseMock.Object.CalculateSurfaceArea(windMillBaseMock.Object);

            return area;
        }

        [Test]
        [TestCase(10, ExpectedResult = 5 * 5 * Math.PI)]
        [TestCase(30, ExpectedResult = 15 * 15 * Math.PI)]
        [ExpectedException(typeof(ArgumentNullException))]
        public double CalculateSurfaceArea_BadTest2(double diameter)
        {
            windMillBaseMock.Object.TurbineDiameter = diameter;                 // setovanje polja TurbineDiameter windMillMock-a
            double area = windGeneratorBaseMock.Object.CalculateSurfaceArea(null);

            return area;
        }
    }
}
