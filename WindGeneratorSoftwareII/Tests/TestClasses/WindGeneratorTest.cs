using Moq;
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
    public class WindGeneratorTest
    {
        Mock<Weather> weatherMock;
        Mock<WindMill> windMillMock;
        Mock<Aggregate> aggregateMock;
        Mock<WindGenerator> windGeneratorMock;

        [SetUp]
        public void SetUp()
        {
            weatherMock = new Mock<Weather>();
            windMillMock = new Mock<WindMill>();
            aggregateMock = new Mock<Aggregate>();
            windGeneratorMock = new Mock<WindGenerator>();
        }

        [Test]
        [TestCase(10)]
        public void WindGeneratorConstructor_GoodParameters(int windMillCnt)
        {
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(1)]
        public void WindGeneratorConstructor_BorderParameters(int windMillCnt)
        {
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException))]
        public void WindGeneratorConstructor_BadParameters1(int windMillCnt)
        {
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(null, null, 10, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindGeneratorConstructor_BadParameters2(Weather weather, WindMill windMill, int windMillCnt, Aggregate aggregate)
        {
            WindGenerator windGenerator = new WindGenerator(weather, windMill, windMillCnt, aggregate);

            Assert.AreEqual(windGenerator.Weather, weather);
            Assert.AreEqual(windGenerator.WindMill, windMill);
            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
            Assert.AreEqual(windGenerator.Aggregate, aggregate);
        }

        // treba pitati da li diameter treba da proveravam u ovoj metodi
        // NE RADI
        [Test]
        [TestCase(10, ExpectedResult = 5 * 5 * Math.PI)]
        public double CalculateSurfaceArea_GoodTest(double diameter)
        {
            windMillMock.Object.TurbineDiameter = diameter;
            double area = windGeneratorMock.Object.CalculateSurfaceArea();

            return area;
        }
    }
}
