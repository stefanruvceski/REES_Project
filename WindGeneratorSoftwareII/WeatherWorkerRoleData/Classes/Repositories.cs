using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWorkerRoleData.Classes
{
    public class Repositories
    {
        public static WeatherRepository weatherRepository = new WeatherRepository();
        public static WindMillRepository windMillRepository = new WindMillRepository();
        public static AggregateRepository aggregateRepository = new AggregateRepository();
        public static WindGeneratorRepository windGeneratorRepository = new WindGeneratorRepository();
    }
}
