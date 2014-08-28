using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using NeumontAssassinV2.Models;

namespace NeumontAssassinV2.ScreenControls
{
    /// <summary>
    /// Interaction logic for WeeklyTraining.xaml
    /// </summary>
    public partial class WeeklyTraining : UserControl, INotifyPropertyChanged
    {
        public WeeklyTraining()
        {
            InitializeComponent();
            this.DataContext = this;
            save.SaveUser();
            save.SaveWeek();
        }

<<<<<<< HEAD
        Person _User = new Person();
        private int count = 1;
        private int MissionLevel = 1;
        //Person person = new Person();
=======
>>>>>>> 96bb176bf1c060b7c8d89260f200301f4e96567d
        GameState save = new GameState();
        private ObservableCollection<Trainning> Train = new ObservableCollection<Trainning>
        {
            new Trainning("Go to the Gym (+Str)"),
            new Trainning("Go for a jog (+Agi)"),
            new Trainning("Read books (+Int)"),
            new Trainning("Go to the Bar (+Cha)")
        };

        public ObservableCollection<Trainning> _Train
        {
            get { return Train; }
            set
            {
                Train = value;
                this.TriggerPropertyChanged("_Train");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TriggerPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

<<<<<<< HEAD
        private void TrainningOptions()
        {
            ComboBox1.SelectedIndex = -1;
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            ComboBox4.SelectedIndex = -1;
            ComboBox5.SelectedIndex = -1;
            ComboBox6.SelectedIndex = -1;

            if (count == 2)
            {
                this.Week.Content = "Week Two";
            }
            if (count == 3)
            {
                this.Week.Content = "Week Three";
            }
        }

        private void ApplyStats()
        {
            int selectedIndex = ComboBox1.SelectedIndex;
            if ((ComboBox1.SelectedIndex == 0) || (ComboBox2.SelectedIndex == 0) || (ComboBox3.SelectedIndex == 0) || (ComboBox4.SelectedIndex == 0) || (ComboBox5.SelectedIndex == 0) || (ComboBox6.SelectedIndex == 0))
            {
                this._User.Player_Strength += 1;
            }
            if ((ComboBox1.SelectedIndex == 1) || (ComboBox2.SelectedIndex == 1) || (ComboBox3.SelectedIndex == 1) || (ComboBox4.SelectedIndex == 1) || (ComboBox5.SelectedIndex == 1) || (ComboBox6.SelectedIndex == 1))
            {
                this._User.Player_Agility += 1;
            }
            if ((ComboBox1.SelectedIndex == 2) || (ComboBox2.SelectedIndex == 2) || (ComboBox3.SelectedIndex == 2) || (ComboBox4.SelectedIndex == 2) || (ComboBox5.SelectedIndex == 2) || (ComboBox6.SelectedIndex == 2))
            {
                this._User.Player_Intellegence += 1;
            }
            if ((ComboBox1.SelectedIndex == 3) || (ComboBox2.SelectedIndex == 3) || (ComboBox3.SelectedIndex == 3) || (ComboBox4.SelectedIndex == 3) || (ComboBox5.SelectedIndex == 3) || (ComboBox6.SelectedIndex == 3))
            {
                this._User.Player_Charisma += 1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((ComboBox1.SelectedIndex == -1) || (ComboBox2.SelectedIndex == -1) || (ComboBox3.SelectedIndex == -1) || (ComboBox4.SelectedIndex == -1) || (ComboBox5.SelectedIndex == -1) || (ComboBox6.SelectedIndex == -1))
            {
                MessageBox.Show("Please Make Sure All Training This Week Is Done.");
            }
            else
            {
                ApplyStats();
                this.TrainButton.Content = "Training Applied";
                this.MissionButton.Visibility = Visibility.Visible;
            }
        }

        private void Missions()
        {
            if (count == 0)
            {
                MainWindow mw = new MainWindow();
                mw.Content = new WeeklyTraining();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = mw;
                mw.Show();
            }
            if (MissionLevel == 1)
            {
                //this is supposed to take you to the second mission after!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                /*
                MainWindow mw = new MainWindow();
                mw.Content = new DrugLord(new Person());
                App.Current.MainWindow.Close();
                App.Current.MainWindow = mw;
                mw.Show();
                 * */
            }
            //dont forget to add the inotify property chanaged event.
            _User.MissionLevel = MissionLevel;
            MissionLevel++;
        }
=======
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
>>>>>>> 96bb176bf1c060b7c8d89260f200301f4e96567d

        }
    }
}
