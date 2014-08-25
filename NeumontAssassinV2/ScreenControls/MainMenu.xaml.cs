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

namespace NeumontAssassinV2.ScreenControls
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        GameState load = new GameState();
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void New_Click_1(object sender, RoutedEventArgs e)
        {
            //create a new person and delete the old one from the file.
        }

        private void Continue_Click_1(object sender, RoutedEventArgs e)
        {
            load.LoadUser();
            load.LoadWeek();
            //I need to then go to the weekly trainning xaml.
        }

        private void Exit_Click_1(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
