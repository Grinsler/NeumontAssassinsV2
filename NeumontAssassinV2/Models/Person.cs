using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeumontAssassinV2.Models
{
    [Serializable]
    public class Person
    {
        public string Player_Name { get; set; }
        public int MissionLevel { get; set; }
        public int Player_Strength { get; set; }
        public int Player_Intellegence { get; set; }
        public int Player_Agility { get; set; }
        public int Player_Charisma { get; set; }
    }
}
