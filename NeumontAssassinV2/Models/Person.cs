using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeumontAssassinV2.Models
{
    [Serializable]
    public class Person : INotifyPropertyChanged
    {
        private string _Player_Name;
        private int _Player_Strength;
        private int _Player_Intellegence;
        private int _Player_Agility;
        private int _Player_Charisma;

        public string Player_Name
        {
            get { return this._Player_Name; }
            set
            {
                this._Player_Name = value;
                this.TriggerPropertyChanged("Player_Name");
            }
        }

        public int Player_Strength
        {
            get { return this._Player_Strength; }
            set
            {
                this._Player_Strength = value;
                this.TriggerPropertyChanged("Player_Strength");
            }
        }

        public int Player_Intellegence
        {
            get { return this._Player_Intellegence; }
            set
            {
                this._Player_Intellegence = value;
                this.TriggerPropertyChanged("Player_Intelligence");
            }
        }

        public int Player_Agility
        {
            get { return this._Player_Agility; }
            set
            {
                this._Player_Agility = value;
                this.TriggerPropertyChanged("Player_Agility");
            }
        }

        public int Player_Charisma
        {
            get { return this._Player_Charisma; }
            set
            {
                this._Player_Charisma = value;
                this.TriggerPropertyChanged("Player_Charisma");
            }
        }

        private void TriggerPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
