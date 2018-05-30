using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WeatherCommon.Classes;

namespace WeatherWorkerRole.Classes
{
    class InternalWeatherJobServer
    {
        #region Fields
        private ServiceHost serviceHost;
        private string internalEndpointName = "InternalRequest";
        #endregion

        public InternalWeatherJobServer()
        {
            NetTcpBinding binding = new NetTcpBinding();
            RoleInstanceEndpoint instanceEndpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[internalEndpointName];
            string endpoint = String.Format($"net.tcp://{instanceEndpoint.IPEndpoint}/{internalEndpointName}");

            serviceHost = new ServiceHost(typeof(WeatherJobServerProvider));
            serviceHost.AddServiceEndpoint(typeof(IWeather), binding, endpoint);
        }

        public void Open()
        {
            try
            {
                serviceHost.Open();
                Trace.WriteLine($"Service host for {internalEndpointName} endpoint type opened successfully at {DateTime.Now}");
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Service host open error for {internalEndpointName} endpoint type. Error message is: {e.Message}");
            }
        }

        public void Close()
        {
            try
            {
                serviceHost.Close();
                Trace.WriteLine($"Service host for {internalEndpointName} endpoint type closed successfully at {DateTime.Now}");
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Service host close error for {internalEndpointName} endpoint type. Error message is: {e.Message}");
            }
        }
    }
}
