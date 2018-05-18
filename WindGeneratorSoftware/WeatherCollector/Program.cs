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
                collector.GetStatesFromWeb();
                Thread.Sleep(5000);
            }
        }
    }
}
