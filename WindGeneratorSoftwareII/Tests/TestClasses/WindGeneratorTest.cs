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
        [TestCase(10, 10)]
        public void WindGeneratorConstructor_GoodParameters(int windMillCnt, int aggregateONCnt, double power)
        {
            // setovanje vrednosti neophodnih polja, konstruktori ob=vih klasa su svakako vec testirani
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object, aggregateONCnt, power);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(1, 0)]
        public void WindGeneratorConstructor_BorderParameters(int windMillCnt, int aggregateONCnt, double power)
        {
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object, aggregateONCnt, power);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(0, -1)]
        [TestCase(-1, -5)]
        [ExpectedException(typeof(ArgumentException))]
        public void WindGeneratorConstructor_BadParameters1(int windMillCnt, int aggregateONCnt, double power)
        {
            windMillMock.Object.Coefficient = 0.30;
            windMillMock.Object.TurbineDiameter = 30;
            WindGenerator windGenerator = new WindGenerator(weatherMock.Object, windMillMock.Object, windMillCnt, aggregateMock.Object, aggregateONCnt, power);

            Assert.AreEqual(windGenerator.WindMillCnt, windMillCnt);
        }

        [Test]
        [TestCase(null, null, 10, null, 10)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindGeneratorConstructor_BadParameters2(Weather weather, WindMill windMill, int windMillCnt, Aggregate aggregate, int aggregateONCnt, double power)
        {
            WindGenerator windGenerator = new WindGenerator(weather, windMill, windMillCnt, aggregate, aggregateONCnt, power);

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
        [TestCase(18, 18, 10, 10, 0.40, 1.29, 45, 10, ExpectedResult = 0)]          // prvi if, pali se kocnica
        [TestCase(5, 5, 10, 8, 0.40, 1.29, 45, 10, ExpectedResult = 512914.088)]    // drugi if, brzina vetra je kriticna, ali vreme koje radi pod tom brzinom nije
        [TestCase(3.04276606358717, 18, 10, 5, 0.40, 1.29, 45, 10, ExpectedResult = 115621.999)]        // else, brzina je manja od max
        public double CalculatePower_GoodTest(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter, int windMillCnt)
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
            windGeneratorMock.Object.WindMillCnt = windMillCnt;
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 3);
        }

        [Test]
        [TestCase(-1, 18, 10, 10, 0.40, 1.29, 45, 10, ExpectedResult = 0)]          
        [TestCase(5, -1, 10, 8, 0.40, 1.29, 45, 10, ExpectedResult = 51291.4088)]
        [TestCase(85, 18, 10, 10, 0.40, 1.29, 45, 10, ExpectedResult = 0)]
        [TestCase(5, 85, 10, 8, 0.40, 1.29, 45, 10, ExpectedResult = 51291.4088)]
        [TestCase(5, 18, -1, 10, 0.40, 1.29, 45, 10, ExpectedResult = 0)]
        [TestCase(5, 18, 10, -1, 0.40, 1.29, 45, 10, ExpectedResult = 0)]
        [TestCase(5, 18, 10, 8, 0.20, 1.29, 45, 10, ExpectedResult = 0)]
        [TestCase(5, 18, 10, 8, 0.50, 1.29, 45, 10, ExpectedResult = 0)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public double CalculatePower_BadTest1(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter, int windMillCnt)
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
            windGeneratorMock.Object.WindMillCnt = windMillCnt;
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }

        [Test]
        [TestCase(5, 18, 10, 10, 0.30, 1.5, 45, 10, ExpectedResult = 0)]
        [TestCase(5, 18, 10, 10, 0.30, 1.29, -5, 10, ExpectedResult = 0)]
        [TestCase(5, 18, 10, 10, 0.30, 1.29, -5, 0, ExpectedResult = 0)]
        [ExpectedException(typeof(ArgumentException))]
        public double CalculatePower_BadTest2(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter, int windMillCnt)
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
            windGeneratorMock.Object.WindMillCnt = windMillCnt;
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }

        [Test]
        [TestCase(18, 18, 10, 10, 0.40, 1.29, 45, 10, ExpectedResult = 0)]
        [ExpectedException(typeof(ArgumentException))]
        public double CalculatePower_BadTest3(double windSpeed, double maxSpeed, int maxSpeedTime, int workingTime, double coefficient, double airDensity, double turbineDiameter, int windMillCnt)
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
            windGeneratorMock.Object.AggregateONCnt = -5;               // properti namerno setovan na nevalidnu vrednost
            windGeneratorMock.Object.WindMillCnt = windMillCnt;
            windGeneratorMock.Object.Weather = weatherMock.Object;
            windGeneratorMock.Object.WindMill = windMillMock.Object;

            double power = windGeneratorMock.Object.CalculatePower();

            return Math.Round(power, 4);
        }
    }
}
