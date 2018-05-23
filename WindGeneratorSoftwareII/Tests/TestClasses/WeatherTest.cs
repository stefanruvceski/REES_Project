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
    public class WeatherTest
    {
        [Test]
        [TestCase("Novi Sad", "sunny", 24, 14, 1012, 3.4)]
        [TestCase("Novi Sad", "cloudy", 8, -4, 989, 5.6)]
        [TestCase("Novi Sad", "foggy", 12, 0, 1008, 4.1)]
        public void WeatherConstructor_GoodParameters(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            Weather weather = new Weather(city, description, maxTemp, minTemp, pressure, windSpeed);

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
        public void WeatherConstructor_BorderParameters(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            Weather weather = new Weather(city, description, maxTemp, minTemp, pressure, windSpeed);

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
        public void WeatherConstructor_BadParameters1(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            Weather weather = new Weather(city, description, maxTemp, minTemp, pressure, windSpeed);

            Assert.AreEqual(weather.City, city);
            Assert.AreEqual(weather.Description, description);
            Assert.AreEqual(weather.MaxTemp, maxTemp);
            Assert.AreEqual(weather.MinTemp, minTemp);
            Assert.AreEqual(weather.Pressure, pressure);
            Assert.AreEqual(weather.WindSpeed, windSpeed);
        }

        [Test]
        [TestCase(null, "sunny", 24, 24, 1012, 3.4)]
        [TestCase("Novi Sad", null, 8, -4, 800, 5.6)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherConstructor_BadParameters2(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            Weather weather = new Weather(city, description, maxTemp, minTemp, pressure, windSpeed);

            Assert.AreEqual(weather.City, city);
            Assert.AreEqual(weather.Description, description);
            Assert.AreEqual(weather.MaxTemp, maxTemp);
            Assert.AreEqual(weather.MinTemp, minTemp);
            Assert.AreEqual(weather.Pressure, pressure);
            Assert.AreEqual(weather.WindSpeed, windSpeed);
        }

        [Test]
        [TestCase("Novi Sad", "sunny", 70, 24, 1012, 3.4)]
        [TestCase("Novi Sad", "cloudy", 8, 70, 800, 5.6)]
        [TestCase("Novi Sad", "foggy", -95, 24, 1100, 4.1)]
        [TestCase("Novi Sad", "foggy", 30, -95, 1100, 4.1)]
        [TestCase("Novi Sad", "foggy", -95, 24, 799, 4.1)]
        [TestCase("Novi Sad", "foggy", -95, 24, 1101, 4.1)]
        [TestCase("Novi Sad", "foggy", -95, 24, 1100, -1)]
        [TestCase("Novi Sad", "foggy", -95, 24, 1100, 81)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WeatherConstructor_BadParameters3(string city, string description, double maxTemp, double minTemp, double pressure, double windSpeed)
        {
            Weather weather = new Weather(city, description, maxTemp, minTemp, pressure, windSpeed);

            Assert.AreEqual(weather.City, city);
            Assert.AreEqual(weather.Description, description);
            Assert.AreEqual(weather.MaxTemp, maxTemp);
            Assert.AreEqual(weather.MinTemp, minTemp);
            Assert.AreEqual(weather.Pressure, pressure);
            Assert.AreEqual(weather.WindSpeed, windSpeed);
        }

        // Testovi za drugi konstruktor

        [Test]
        [TestCase("Novi Sad")]
        public void WeatherConstructor_GoodParameters(string city)
        {
            Weather weather = new Weather(city);

            Assert.AreEqual(weather.City, city);
        }

        [Test]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeatherConstructor_BadParameters1(string city)
        {
            Weather weather = new Weather(city);

            Assert.AreEqual(weather.City, city);
        }

        [Test]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void WeatherConstructor_BadParameters2(string city)
        {
            Weather weather = new Weather(city);

            Assert.AreEqual(weather.City, city);
        }
    }
}
