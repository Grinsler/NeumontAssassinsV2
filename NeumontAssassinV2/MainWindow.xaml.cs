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
using NeumontAssassinV2.Missions;
using NeumontAssassinV2.Models;
using NeumontAssassinV2.ScreenControls;

namespace NeumontAssassinV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainMenu mm;
        Person person = new Person();
        public MainWindow()
        {
            InitializeComponent();
            mm = new MainMenu(person);
            MainGrid.Children.Clear();                     
            MainGrid.Children.Add(mm);
        }
    }
}
