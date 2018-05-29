using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WeatherAdminWPF
{
    /// <summary>
    /// Interaction logic for Graphics.xaml
    /// </summary>
    /// 
   
    public partial class Graphics : Window
    {
        public  Dictionary<string, GearedValues<double>> Powers { get; set; }
        public Graphics()
        {
            Powers = new Dictionary<string, GearedValues<double>>()
            {
                { "Novi Sad" ,new GearedValues<double>()},
                { "Subotica" ,new GearedValues<double>()},
                { "Sombor" ,new GearedValues<double>()},
                { "Kikinda" ,new GearedValues<double>()},
                { "Zrenjanin",new GearedValues<double>() },
                {"Vrsac", new GearedValues<double>()},
                { "Sremska Mitrovica" ,new GearedValues<double>()},
                { "Pancevo" ,new GearedValues<double>()}
            };
            DataContext = this;
            InitializeComponent();
        }
    }
}
