using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeumontAssassinV2.Models
{
    [Serializable]
    public class Trainning
    {
        private string TrainningType;
        private int Strength;
        private int Intelligence;
        private int Agility;
        private int Charisma;

        public Trainning() { }

        public Trainning(string trainningType)
        {
            TrainningType = trainningType;
        }

        public int _Charisma
        {
            get { return Charisma; }
            set
            {
                Charisma = value;
                this.TriggerPropertyChanged("_Charisma");
            }
        }

        public int _Agility
        {
            get { return Agility; }
            set
            {
                Agility = value;
                this.TriggerPropertyChanged("_Agility");
            }
        }

        public string _TrainningType
        {
            get { return TrainningType; }
            set { TrainningType = value; }
        }

        public int _Intelligence
        {
            get { return Intelligence; }
            set
            {
                Intelligence = value;
                this.TriggerPropertyChanged("_Intelligence");
            }
        }

        public int _Strength
        {
            get { return Strength; }
            set
            {
                Strength = value;
                this.TriggerPropertyChanged("_Strength");
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
    }
}
