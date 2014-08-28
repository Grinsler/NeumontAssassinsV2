using NeumontAssassinV2.Models;
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
    public partial class MainMenu : UserControl
    {
        GameState load = new GameState();

        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void New_Click_1(object sender, RoutedEventArgs e)
        {
            NewStart();
        }

        private void NewStart()
        {
            MainWindow mw = new MainWindow();
            mw.Content = new PreQuestions();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();
        }

        private void CountinueStart()
        {
            //load.LoadUser();
            //load.LoadWeek();
            MainWindow mw = new MainWindow();
            //change the content if we switch where the load will take the player
            mw.Content = new WeeklyTraining();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();
        }

        private void Continue_Click_1(object sender, RoutedEventArgs e)
        {
            CountinueStart();
        }

        private void Exit_Click_1(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
