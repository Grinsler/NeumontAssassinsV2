using NeumontAssassinV2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NeumontAssassinV2.ScreenControls
{
    public class GameState
    {
        private MainMenu train { get; set; }
        private MainMenu MyWindow { get; set; }
        IFormatter format = new BinaryFormatter();
        string PlayerURL = "AssassinsPlayer.bin";
        string WeekURL = "AssassinsWeek.bin";
        Stream stream;

        /// <summary>
        /// This method saves the player instance of the game, it also saves the trainning stats.
        /// </summary>
        public void SaveUser()
        {
            File.Delete(PlayerURL);
            stream = new FileStream(PlayerURL, FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                format.Serialize(stream, MyWindow.p);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            stream.Close();
        }

        public void SaveWeek()
        {
            File.Delete(WeekURL);
            stream = new FileStream(WeekURL, FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                format.Serialize(stream, train.t);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            stream.Close();
        }

        public void LoadWeek()
        {
            stream = new FileStream(WeekURL, FileMode.Create, FileAccess.Write, FileShare.None);
            Training _Train = (Training)format.Deserialize(stream);
            _Train = train.t;
            _Train._Agility = train.t._Agility;
            _Train._Charisma = train.t._Charisma;
            _Train._Intelligence = train.t._Intelligence;
            _Train._Strength = train.t._Strength;
            _Train._TrainningType = train.t._TrainningType;
            stream.Close();
            Console.WriteLine(_Train._Agility);
            Console.WriteLine(_Train._Charisma);
            Console.WriteLine(_Train._Intelligence);
            Console.WriteLine(_Train._Strength);
            Console.WriteLine(_Train._TrainningType);
        }

        public void LoadUser()
        {
            stream = new FileStream(PlayerURL, FileMode.Open, FileAccess.Read, FileShare.Read);
            Person _Person = (Person)format.Deserialize(stream);
            _Person = MyWindow.p;
            _Person.Player_Strength = MyWindow.p.Player_Strength;
            _Person.Player_Agility = MyWindow.p.Player_Agility;
            _Person.Player_Charisma = MyWindow.p.Player_Charisma;
            _Person.Player_Intellegence = MyWindow.p.Player_Intellegence;
            _Person.Player_Name = MyWindow.p.Player_Name;
            stream.Close();
            Console.WriteLine(_Person.Player_Strength);
            Console.WriteLine(_Person.Player_Agility);
            Console.WriteLine(_Person.Player_Charisma);
            Console.WriteLine(_Person.Player_Intellegence);
            Console.WriteLine(_Person.Player_Name);
        }
    }
}