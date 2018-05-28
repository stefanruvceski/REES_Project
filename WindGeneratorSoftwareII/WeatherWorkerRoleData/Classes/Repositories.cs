using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWorkerRoleData.Classes
{
    public class Repositories
    {
        public static WindMillRepository windMillRepository = new WindMillRepository();
        public static WindGeneratorRepository windGeneratorRepository = new WindGeneratorRepository();
        public static WeatherRepository weatherRepository = new WeatherRepository();
        public static AggregateRepository aggregateRepository = new AggregateRepository();
    }
}
