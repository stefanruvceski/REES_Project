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
        ServiceHost sh;
        IWeather proxy;

        // nazvao sam sa _ jer ima vec u kodu WindGenerators, da ne rizikujem da se Binding pogubi
        // ako stavim WindGenerator, a ne WindGeneratorBase, nece moci da se lista progura kroz konstruktor binding liste
        public static BindingList<WindGenerator> windGenerators { get; set; }      

        public MainWindow()
        {
            // WindGeneratorRepository repository = new WindGeneratorRepository();
            //Wind_Generators = new BindingList<WindGeneratorBase>(repository.GetAllWindGenerators());
            windGenerators = new BindingList<WindGenerator>();
            CreateChannelFactory();
            windGenerators.Add(proxy.GetWindGenerator());
            Thread.Sleep(1000);
            DataContext = this;
            InitializeComponent();
            //CreateServiceHost();
           
           
        }

        private void CreateServiceHost()
        {
            sh = new ServiceHost(typeof(WeatherAdminWPF.Classes.Admin));
            sh.AddServiceEndpoint(typeof(INotify), new NetTcpBinding(), "net.tcp://localhost:11001/Inotify");
            sh.Open();
        }
        
        public void AddWeather()
        {
            windGenerators.Add(proxy.GetWindGenerator());
           
        }

        private void CreateChannelFactory()
        {
            ChannelFactory<IWeather> factory = new ChannelFactory<IWeather>(new NetTcpBinding(), new EndpointAddress("net.tcp://127.255.0.2:502/InputRequest")); // promeniti na svakom kompu
            proxy = factory.CreateChannel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWeather();
        }
    }
}
