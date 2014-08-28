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
        private MainMenu menu { get; set; }
        Training train = new Training();

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
                format.Serialize(stream, menu.User.Player_Agility);
                format.Serialize(stream, menu.User.MissionLevel);
                format.Serialize(stream, menu.User.Player_Charisma);
                format.Serialize(stream, menu.User.Player_Intellegence);
                format.Serialize(stream, menu.User.Player_Name);
                format.Serialize(stream, menu.User.Player_Strength);
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
                format.Serialize(stream, train);
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
            _Train = train;
            _Train._Agility = train._Agility;
            _Train._Charisma = train._Charisma;
            _Train._Intelligence = train._Intelligence;
            _Train._Strength = train._Strength;
            _Train._TrainningType = train._TrainningType;
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
            _Person.Player_Strength = menu.User.Player_Strength;
            _Person.Player_Agility = menu.User.Player_Agility;
            _Person.Player_Charisma = menu.User.Player_Charisma;
            _Person.Player_Intellegence = menu.User.Player_Intellegence;
            _Person.Player_Name = menu.User.Player_Name;
            _Person.MissionLevel = menu.User.MissionLevel;
            stream.Close();
            Console.WriteLine(_Person.Player_Strength);
            Console.WriteLine(_Person.Player_Agility);
            Console.WriteLine(_Person.Player_Charisma);
            Console.WriteLine(_Person.Player_Intellegence);
            Console.WriteLine(_Person.Player_Name);
        }
    }
}