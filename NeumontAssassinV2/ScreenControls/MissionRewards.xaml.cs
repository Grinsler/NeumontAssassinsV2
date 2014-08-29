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
using System.Windows.Shapes;

namespace NeumontAssassinV2.ScreenControls
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MissionRewards : UserControl
    {
        int failCounters;
        Person person;
        Uri imgsrc;
        BitmapImage bmp;

        Random r = new Random();

        public MissionRewards(int i, Person p)
        {
            InitializeComponent();
            person = p;
            failCounters = i;
            ChangeLabel();
        }

        public void ChangeLabel()
        {
            if (failCounters == 0)
            {
                imgsrc = new Uri("pack://application:,,,/Images/RewardSystem/Victory.jpg");
                bmp = new BitmapImage(imgsrc);
                image1.Source = bmp;

                Results.Content = "Congratulations on a flawless mission. \n For your preformance, we will grant you special train in one of your abilties";
            }
            else if (failCounters == 1)
            {
                Results.Content = "You completed the mission, but that's all. Get back to training";
                but_Agl.Content = "Next";
                but_cha.Visibility = Visibility.Hidden;
                but_Int.Visibility = Visibility.Hidden;
                but_Str.Visibility = Visibility.Hidden;

                imgsrc = new Uri("pack://application:,,,/Images/RewardSystem/MissionSemiCompleted.jpg");
                bmp = new BitmapImage(imgsrc);
                image1.Source = bmp;
            }
            else
            {
                but_Agl.Content = "Next";
                but_cha.Visibility = Visibility.Hidden;
                but_Int.Visibility = Visibility.Hidden;
                but_Str.Visibility = Visibility.Hidden;

                imgsrc = new Uri("pack://application:,,,/Images/RewardSystem/MissionFail.jpg");
                bmp = new BitmapImage(imgsrc);
                image1.Source = bmp;

                int Losestat = r.Next(1, 5);
                if (Losestat == 1)
                {
                    person.Player_Strength--;
                    Results.Content = "Nice fail, your preformance warrents a cut in your paycheck (-1 Strength)";
                }
                else if (Losestat == 2)
                {
                    Results.Content = "Nice fail, your preformance warrents a cut in your paycheck (-1 Intellegence)";
                    person.Player_Intellegence--;
                }
                else if (Losestat == 3)
                {
                    Results.Content = "Nice fail, your preformance warrents a cut in your paycheck (-1 Agility)";
                    person.Player_Agility--;
                }
                else if (Losestat == 2)
                {
                    Results.Content = "Nice fail, your preformance warrents a cut in your paycheck (-1 Charisma)";
                    person.Player_Charisma--;
                }
            }
        }

        private void but_Str_Click(object sender, RoutedEventArgs e)
        {
            person.Player_Strength++;
            GoToWeeklyTraining();
        }

        private void but_Int_Click(object sender, RoutedEventArgs e)
        {
            person.Player_Intellegence++;
            GoToWeeklyTraining();
        }

        private void but_Agl_Click(object sender, RoutedEventArgs e)
        {
            person.Player_Agility++;
            GoToWeeklyTraining();
        }

        private void but_cha_Click(object sender, RoutedEventArgs e)
        {
            person.Player_Charisma++;
            GoToWeeklyTraining();
        }

        private void GoToWeeklyTraining()
        {
            //I need to take them to the week they left in and then appply it to this weekly training window
            MainWindow mw = new MainWindow();
            mw.Content = new WeeklyTraining(person);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();
        }
    }
}
