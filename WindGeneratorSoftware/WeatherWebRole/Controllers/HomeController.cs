using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WeatherCommon.Classes;

namespace WeatherWebRole.Controllers
{
    public class HomeController : Controller
    {
        IWeather proxy;
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Update1()
        {
            return View(Update());
        }

        

        public WindGenerator Update()
        {
            var binding = new NetTcpBinding();
            IPEndPoint ipAddress = RoleEnvironment.Roles["WeatherWorkerRole"].Instances[0].InstanceEndpoints["InternalRequest"].IPEndpoint;
            ChannelFactory<IWeather> factory = new ChannelFactory<IWeather>(binding, new EndpointAddress($"net.tcp://{ipAddress}/InternalRequest"));
            proxy = factory.CreateChannel();

            return proxy.GetWeather();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}