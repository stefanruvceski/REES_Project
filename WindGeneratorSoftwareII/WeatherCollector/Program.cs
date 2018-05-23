using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherCollector.Classes.WeatherStateCollector collector = new Classes.WeatherStateCollector();

            while (true)
            {
                try
                {
                    collector.GetStatesFromWeb();
                    Console.WriteLine("Weather data is collected");
                }
                catch (Exception)
                {
                    Console.WriteLine("There is no servicehost yet.");
                }
                Thread.Sleep(5000);
            }
        }
    }
}
