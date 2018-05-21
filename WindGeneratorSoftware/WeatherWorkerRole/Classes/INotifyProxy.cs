using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherCommon.Classes;

namespace WeatherWorkerRole.Classes
{
    public class INotifyProxy
    {
        static INotify proxy;

        public static INotify IProxy()
        {
            ChannelFactory<INotify> factory = new ChannelFactory<INotify>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:11001/INotify"));
            return factory.CreateChannel();
        }

        public static INotify Proxy { get => IProxy(); set => proxy = value; }
    }
}
