using NeumontAssassinV2.Missions;
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
        PreQuestions question;
        DrugLord dl;
        public Training t { get; set; }
        public WeeklyTraining WeekTrain { get; set; }
        public Person p { get; set; }

        public MainMenu()
        {
            //MainGrid.Children.Clear();
            p = new Person();
            ////for testing purposes:
            p.Player_Agility = 5;
            p.Player_Charisma = 5;
            p.Player_Intellegence = 5;
            p.Player_Strength = 5;
            p.Player_Name = "Test1";
            InitializeComponent();
            t = new Training();
            WeekTrain = new WeeklyTraining(this);
            question = new PreQuestions();
            dl = new DrugLord(p);
            MainGrid.Children.Add(dl);
            //MainGrid.Children.Add(question);
            //MainGrid.Children.Remove(question);
        }
        
        private void New_Click_1(object sender, RoutedEventArgs e)
        {
            //create a new person and delete the old one from the file.
            MainWindow mw = new MainWindow();
            mw.Content = new PreQuestions();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();
        }

        private void Continue_Click_1(object sender, RoutedEventArgs e)
        {
            load.LoadUser();
            load.LoadWeek();
            //I need to then go to the weekly trainning xaml.

            //here's the code for that, but shouldn't the continue pick up at introducing the mission?:
            MainWindow mw = new MainWindow();
            mw.Content = new PreQuestions();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();
        }

        private void Exit_Click_1(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
