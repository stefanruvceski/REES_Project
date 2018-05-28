using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherCommon.Classes;
using WeatherWorkerRoleData.Classes;

namespace WeatherAdminWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWeather proxy;

        public static BindingList<WindGenerator> windGenerators { get; set; }

        public MainWindow()
        {
            windGenerators = new BindingList<WindGenerator>();
            CreateChannelFactory();
            AddWeather();
            DataContext = this;
            InitializeComponent();


        }
        public void AddWeather()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    AddWeatherToList();
                    Thread.Sleep(1000);
                }

            }).Start();
        }

        List<string> cities = new List<string>()
        {
            "Novi Sad","Subotica","Sombor","Kikinda","Zrenjanin","Vrsac",
            "Sremska Mitrovica","Pancevo"
        };

        private void AddWeatherToList()
        {
            foreach (string city in cities)
            {

                this.Dispatcher.Invoke((Action)(() =>
                {
                    windGenerators.Add(proxy.GetWindGenerator(city));
                    
                }));
            }
           

        }

        private void CreateChannelFactory()
        {
            //ChannelFactory<IWeather> factory = new ChannelFactory<IWeather>(new NetTcpBinding(), new EndpointAddress("net.tcp://127.255.0.2:502/InputRequest")); // promeniti na svakom kompu
            ChannelFactory<IWeather> factory = new ChannelFactory<IWeather>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:502/InputRequest"));
            proxy = factory.CreateChannel();
        }
    }
}
