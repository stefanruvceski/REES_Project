using Moq;
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
    public class WeatherBaseTest
    {
        Mock<Weather> weatherMock;

        [SetUp]
        public void SetUp()
        {
            weatherMock = new Mock<Weather>();
        }

        [Test]
        [TestCase("Novi Sad", "sunny", 24, 14, 1012, 3.4)]
        [TestCase("Novi Sad", "cloudy", 8, -4, 989, 5.6)]
        [TestCase("Novi Sad", "foggy", 12, 0, 1008, 4.1)]
        public void WeatherBaseConstructor_GoodParameters(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            WeatherBase weather = new WeatherBase(city, description, maxTemp, minTemp, pressure, windSpeed);

            Assert.AreEqual(weather.City, city);
            Assert.AreEqual(weather.Description, description);
            Assert.AreEqual(weather.MaxTemp, maxTemp);
            Assert.AreEqual(weather.MinTemp, minTemp);
            Assert.AreEqual(weather.Pressure, pressure);
            Assert.AreEqual(weather.WindSpeed, windSpeed);
        }

        [Test]
        [TestCase("Novi Sad", "sunny", 24, 24, 1012, 3.4)]
        [TestCase("Novi Sad", "cloudy", 8, -4, 800, 5.6)]
        [TestCase("Novi Sad", "foggy", 12, 0, 1100, 4.1)]
        [TestCase("Novi Sad", "foggy", 12, 0, 1100, 0)]
        [TestCase("Novi Sad", "foggy", 12, 0, 1100, 80)]
        public void WeatherBaseConstructor_BorderParameters(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            WeatherBase weather = new WeatherBase(city, description, maxTemp, minTemp, pressure, windSpeed);

            Assert.AreEqual(weather.City, city);
            Assert.AreEqual(weather.Description, description);
            Assert.AreEqual(weather.MaxTemp, maxTemp);
            Assert.AreEqual(weather.MinTemp, minTemp);
            Assert.AreEqual(weather.Pressure, pressure);
            Assert.AreEqual(weather.WindSpeed, windSpeed);
        }

        [Test]
        [TestCase("", "sunny", 24, 24, 1012, 3.4)]
        [TestCase("Novi Sad", "", 8, -4, 800, 5.6)]
        [TestCase("Novi Sad", "foggy", 12, 24, 1100, 4.1)]
        [ExpectedException(typeof(ArgumentException))]
        public void WeatherBaseConstructor_BadParameters1(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            WeatherBase weather = new WeatherBase(city, description, maxTemp, minTemp, pressure, windSpeed);
        }

        [Test]
        [TestCase(null, "sunny", 24, 24, 1012, 3.4)]
        [TestCase("Novi Sad", null, 8, -4, 800, 5.6)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherBaseConstructor_BadParameters2(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            WeatherBase weather = new WeatherBase(city, description, maxTemp, minTemp, pressure, windSpeed);
        }

        [Test]
        [TestCase("Novi Sad", "sunny", 70, 24, 1012, 3.4)]
        [TestCase("Novi Sad", "cloudy", 8, 70, 800, 5.6)]
        [TestCase("Novi Sad", "foggy", -95, 24, 1100, 4.1)]
        [TestCase("Novi Sad", "foggy", 30, -95, 1100, 4.1)]
        [TestCase("Novi Sad", "foggy", 30, 24, 799, 4.1)]
        [TestCase("Novi Sad", "foggy", 30, 24, 1101, 4.1)]
        [TestCase("Novi Sad", "foggy", 30, 24, 1100, -1)]
        [TestCase("Novi Sad", "foggy", 30, 24, 1100, 81)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WeatherBaseConstructor_BadParameters3(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            WeatherBase weather = new WeatherBase(city, description, maxTemp, minTemp, pressure, windSpeed);
        }

        // Testovi za drugi konstruktor
        [Test]
        public void WeatherBaseConstructor_GoodParameters()
        {
            WeatherBase weather = new WeatherBase(weatherMock.Object);

            Assert.AreEqual(weather.AirDensity, weatherMock.Object.AirDensity);
            Assert.AreEqual(weather.City, weatherMock.Object.City);
            Assert.AreEqual(weather.Description, weatherMock.Object.Description);
            Assert.AreEqual(weather.MaxTemp, weatherMock.Object.MaxTemp);
            Assert.AreEqual(weather.MinTemp, weatherMock.Object.MinTemp);
            Assert.AreEqual(weather.Pressure, weatherMock.Object.Pressure);
            Assert.AreEqual(weather.WindSpeed, weatherMock.Object.WindSpeed);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherBaseConstructor_BadParameters()
        {
            WeatherBase weather = new WeatherBase(null);
        }
    }
}
