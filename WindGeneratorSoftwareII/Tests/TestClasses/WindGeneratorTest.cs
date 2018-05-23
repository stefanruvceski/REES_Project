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
            // setovanje vrednosti neophodnih polja, konstruktori ob=vih klasa su svakako vec testirani
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(1)]
        public void WindGeneratorConstructor_BorderParameters(int windMillCnt)
        {
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException))]
        public void WindGeneratorConstructor_BadParameters1(int windMillCnt)
        {
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
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
        [Test]
        [TestCase(10, ExpectedResult = 5 * 5 * Math.PI)]
        [TestCase(30, ExpectedResult = 15 * 15 * Math.PI)]
        [TestCase(50, ExpectedResult = 25 * 25 * Math.PI)]
        public double CalculateSurfaceArea_GoodTest(double diameter)
        {
            windMillMock.Object.TurbineDiameter = diameter;                 // setovanje polja TurbineDiameter windMillMock-a
            windGeneratorMock.Object.WindMill = windMillMock.Object;        // setovanje polja WindMill windGeneratorMock-a
            double area = windGeneratorMock.Object.CalculateSurfaceArea();            

            return area;
        }

        [Test]
        [TestCase(0, ExpectedResult = 5 * 5 * Math.PI)]
        [TestCase(-5, ExpectedResult = 15 * 15 * Math.PI)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public double CalculateSurfaceArea_BadTest(double diameter)
        {
            windMillMock.Object.TurbineDiameter = diameter;                 // setovanje polja TurbineDiameter windMillMock-a
            windGeneratorMock.Object.WindMill = windMillMock.Object;        // setovanje polja WindMill windGeneratorMock-a
            double area = windGeneratorMock.Object.CalculateSurfaceArea();

            return area;
        }

        [Test]      
        [TestCase(18, 18, 10, 10, 0.40, 1.29, 45, ExpectedResult = 0)]          // prvi if, pali se kocnica
        [TestCase(5, 5, 10, 8, 0.40, 1.29, 45, ExpectedResult = 51291.4088)]    // drugi if, brzina vetra je kriticna, ali vreme koje radi pod tom brzinom nije
        [TestCase(3.04276606358717, 18, 10, 5, 0.40, 1.29, 45, ExpectedResult = 11559.5335)]        // else, brzina je manja od max
        public double CalculatePower_GoodTest(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter)
        {
            // setovanje odgovarajucih polja weatherMock-a
            weatherMock.Object.AirDensity = airDensity;
            weatherMock.Object.WindSpeed = windSpeed;

            // setovanje odgovarajucih polja windMillMock-a
            windMillMock.Object.Coefficient = coefficient;
            windMillMock.Object.MaxSpeed = maxSpeed;
            windMillMock.Object.MaxSpeedTime = maxSpeedTime;
            windMillMock.Object.WorkingTime = workingTime;
            windMillMock.Object.TurbineDiameter = turbineDiameter;

            // setovanje odgovarajucih polja windGeneratorMock-a
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }

        [Test]
        [TestCase(-1, 18, 10, 10, 0.40, 1.29, 45, ExpectedResult = 0)]          
        [TestCase(5, -1, 10, 8, 0.40, 1.29, 45, ExpectedResult = 51291.4088)]
        [TestCase(85, 18, 10, 10, 0.40, 1.29, 45, ExpectedResult = 0)]
        [TestCase(5, 85, 10, 8, 0.40, 1.29, 45, ExpectedResult = 51291.4088)]
        [TestCase(5, 18, -1, 10, 0.40, 1.29, 45, ExpectedResult = 0)]
        [TestCase(5, 18, 10, -1, 0.40, 1.29, 45, ExpectedResult = 0)]
        [TestCase(5, 18, 10, -1, 0.20, 1.29, 45, ExpectedResult = 0)]
        [TestCase(5, 18, 10, -1, 0.50, 1.29, 45, ExpectedResult = 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public double CalculatePower_BadTest1(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter)
        {
            // setovanje odgovarajucih polja weatherMock-a
            weatherMock.Object.AirDensity = airDensity;
            weatherMock.Object.WindSpeed = windSpeed;

            // setovanje odgovarajucih polja windMillMock-a
            windMillMock.Object.Coefficient = coefficient;
            windMillMock.Object.MaxSpeed = maxSpeed;
            windMillMock.Object.MaxSpeedTime = maxSpeedTime;
            windMillMock.Object.WorkingTime = workingTime;
            windMillMock.Object.TurbineDiameter = turbineDiameter;

            // setovanje odgovarajucih polja windGeneratorMock-a
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }

        [Test]
        [TestCase(5, 18, 10, 10, 0.30, 1.5, 45, ExpectedResult = 0)]
        [TestCase(5, 18, 10, 10, 0.30, 1.29, -5, ExpectedResult = 0)]
        [ExpectedException(typeof(ArgumentException))]
        public double CalculatePower_BadTest2(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter)
        {
            // setovanje odgovarajucih polja weatherMock-a
            weatherMock.Object.AirDensity = airDensity;
            weatherMock.Object.WindSpeed = windSpeed;

            // setovanje odgovarajucih polja windMillMock-a
            windMillMock.Object.Coefficient = coefficient;
            windMillMock.Object.MaxSpeed = maxSpeed;
            windMillMock.Object.MaxSpeedTime = maxSpeedTime;
            windMillMock.Object.WorkingTime = workingTime;
            windMillMock.Object.TurbineDiameter = turbineDiameter;

            // setovanje odgovarajucih polja windGeneratorMock-a
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }
    }
}
