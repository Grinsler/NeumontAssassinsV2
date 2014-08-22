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
        }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
