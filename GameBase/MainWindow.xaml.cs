using farmbase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ManagersHolder.Instance.RegisterAllManagers();
            TimeManager.Instace.Start();
            TimeManager.Instace.ShowTime += Instace_ShowTime;
            TimeManager.Instace.SpendDay += Instace_SpendDay;
            TimeManager.Instace.StartFromTime(new Time(2, 3, 23, 5));
        }

        private void Instace_SpendDay(TimeManager holder, Time time)
        {
            Console.WriteLine("one day passed");
        }

        private void Instace_ShowTime(TimeManager holder, Time time)
        {
            TimeShower.Dispatcher.BeginInvoke((Action)(() => 
            {
                TimeShower.Text = string.Format("Day:{0},time:{1:D2}:{2:D2}", time.Day, time.Hour, time.Min);
            }));
            
            //Console.WriteLine("Day:{0},time:{1:D2}:{2:D2}", time.Day, time.Hour, time.Min);
        }
    }
}
