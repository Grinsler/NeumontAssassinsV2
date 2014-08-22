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
using NeumontAssassinV2.Models;

namespace NeumontAssassinV2.Missions
{
    /// <summary>
    /// Interaction logic for DrugLord.xaml
    /// </summary>
    public partial class DrugLord : UserControl
    {
        Person person = new Person();

        public DrugLord(Person p)
        {
            InitializeComponent();
            person = p;
        }
        int counter = 0;
        int choiceCounter = 1;
        int userchoice = 0;

        public List<string> drugThoughs = new List<string>
        {
            //backgroud info
            "Cevon: Good, you made it. Your first target is a local drug dealer - he and his gang have been causing trouble for our agents operating in the area.",
            "Cevon: They’re just common rabble really. Your mission is to take out the dealer, and any of his thugs if necessary. If you are discovered, the agency will disavow any knowledge of your existence.",
            "Cevon: Take out the dealer: it can’t be any simpler than that",
            "Cevon: Down by 1337 street; in the back alley of Path and Exile.",
            "Player: Affirmative.",
            "Cevon: “Get going then.",
            "Player: This is it. I can’t afford to mess this up..",
            
            //dumpster action
            "Choice",
            //agility success
            "Thats right, I should utilize my athleticism here.",
            "I swiftly scaled over the dumpster and over the fence, landing down into the construction site. It’s Sunday, so the workers are all at home. I have to make my way to the other side of the site and climb over the fence blocking the main street...",
            "Luckily no one seemed to notice.",
            //agility fail
            "Argh, I definitely botched that jump - leg hurts… Shouldn’t be too much trouble once I get past the gate.",
            "That didn’t go as planned... Hope no one noticed me.",
            //fight success
            "Wow, good thing I spent so much time building my muscles. Guy didn’t even know what was coming.",
            //fight fail
            "The guard blocks your punches and knocks you in the stomach. Thankfully, before he can finish the job, you run off.",
            //talk success
            "Look, I don’t want any trouble, just let me pass and things will be just fine.",
            "Gang member: Alright, alright. You can pass, man.",
            //talk fail
            "Look, I don’t want any trouble, just let me pass and things will be just fine.",
            "Gang member: I don’t think so, you’re not goin’ anywhere, chump!",

            //1st attack chance
            "choice",
            "There he is!",
            "My target, the dealer, is right there walking with another person. I don’t think they’ve noticed me yet.",
            "I moved like lightning. All this training has payed off",
            //attack success
            "I lifted my knife to the man on the right’s neck and raised my silenced pistol the the base of the dealer’s head all within a fraction of a second",
            "My knife moved smoothly across the mans neck making quick work of him as i pulled the trigger in my left hand.",
            "I felt my bullet find its mark (Its kinda hard to miss from this close)",
            "They both fell to the ground, but I did not have time to stand around and admire my handiwork",
            "I headed back to HQ without a hitch",
            //attack fail
            "Oh boy… The dealer definitely knows I’m coming…",
            "Druglod: Better luck next time, loser.",
            "At that, the dealer sprints off, and despite you chasing him it seems he vanished within the crowds of people. Only thing to do now is report back.",
            //attack fail and death
            "What the-?!",
            //after waiting
            "I could ambush him here or i could walk up like a customer...",
            //strength kill
            "Hm. He was frailer than I was expecting. One little crack to the head and he’s done for. Well, better head back to base.",
        };

        #region logString
        string[] logs = new string[27]
        {
            "Player: Hello, I am the MC.", 
            "Cevon: oh hi, I am cevon",
            "Player: cool wanna play rack paper scissors?",
            "Cevon: ok, rock,paper, scissors...",
            "*SHOOT*",

            "go_to_Choice",
            //Rock paper scissors paths
            //6
            "Player: ROCK",
            "Cevon: SCISSORS",
            "Cevon Aww I lost",

            "to_18",
            //10
            "Player: PAPER",
            "Cevon: SCISSORS",
            "Cevon: Hahaha I won",

            "to_18",
            //14
            "Player: SCISSORS",
            "Cevon: SCISSORS",
            "Cevon: oh well it was a tie...",

            "to_18",
            //Kill paths
            //18
            "Player: cool now im gonna kill you",
            "Cevon: uuuuuu wait what...",

            "go_to_Choice",
            //21
            "*Bang*... *dead*...",

            "to_25",
            //23
            "Player: hahah just kidding",

            "to_25",
            //END 25
            "Thanks for playing",
            "END"
        };
#endregion


        private void CycleDialogue(object sender, MouseButtonEventArgs e)
        {
            if (logs[counter].Equals("to_18"))
            {
                counter = 18;
            }
            else if (logs[counter].Equals("to_25"))
            {
                counter = 25;
            }
            else if (logs[counter].Equals("END"))
            {
                end();
            }
            if (!logs[counter].Equals("go_to_Choice"))
            {
                testLabel.Content = logs[counter];
                counter++;
            }
             
            else
            {
                testLabel.Visibility = Visibility.Hidden;
                switch (choiceCounter)
                {
                    case 1:
                        //choice1();
                        break;
                    case 2:
                        //choice2();
                        break;
                }
                
                choiceCounter++;
            }
            
        }

        public void choice_InitalDumpster()
        {
            testLabe2.Content = "What should I pick...";
            testLabe2.Visibility = Visibility.Visible;
            if (person.Player_Agility > 3)
            {
                but1.Content = "Jump the dumpster";
                but1.Visibility = Visibility.Visible;
            }
            else
            {
                but1.Visibility = Visibility.Hidden;
            }
            but2.Content = "Confront the gang member";
            but3.Content = "Persuade the gang member";
            
            but2.Visibility = Visibility.Visible;
            but3.Visibility = Visibility.Visible;    

        }

        public void choice_1stKillChance()
        {
            testLabe2.Content = "My target, the dealer, is right there walking with another person. I don’t think they’ve noticed me yet.";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Attack them";
            but2.Content = "Wait";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
        }
        public void choice_Dealertalk1()
        {
            testLabe2.Content = "Dealer: You buying?";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "No. You’re buying. A one-way ticket to deadville. Population: You";
            but2.Content = "Yeah. How much are you charging";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
        }
        public void choice_HowToKill()
        {
            testLabe2.Content = "Good. He doesn’t notice me. Hmm.. How should I go about this?";
            testLabe2.Visibility = Visibility.Visible;
            but1.Visibility = Visibility.Visible;

            if (person.Player_Agility > 5)
            {
                but1.Content = "Knife him";
            }
            else
            {
                but1.Content = "Quickly pull out a silenced pistol and shoot him in the head";
            }

            if (person.Player_Strength > 5)
            {
                but2.Visibility = Visibility.Visible;
                but2.Content = "Slam him against the back of the wall and crack his skull open";
            }
            if (person.Player_Charisma > 5)
            {
                but2.Visibility = Visibility.Visible;
                but2.Content = "Convince him to quit selling drugs, then kill him while he’s unaware";
            }
        }
        public void end()
        {
            testLabel.Visibility = Visibility.Hidden;
            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
        }
        private void but1_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 0:
                    counter = 6;
                    break;
                case 1:
                    counter = 21;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            userchoice++;
        }

        private void but2_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 0:
                    counter = 10;
                    break;
                case 1:
                    counter = 23;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            userchoice++;
        }

        private void but3_choice(object sender, RoutedEventArgs e)
        {
            //userchoice = 3;
            counter = 14;

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            userchoice++;
        }

        private void but4_choice(object sender, RoutedEventArgs e)
        {

        }

        //Button Styling
        private void Button_Choice4_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.but4.Foreground.Equals(Brushes.Black))
            {
                this.but4.Foreground = (Brushes.White);
            }
            else
            {
                this.but4.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice3_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.but3.Foreground.Equals(Brushes.Black))
            {
                this.but3.Foreground = (Brushes.White);
            }
            else
            {
                this.but3.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.but2.Foreground.Equals(Brushes.Black))
            {
                this.but2.Foreground = (Brushes.White);
            }
            else
            {
                this.but2.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.but1.Foreground.Equals(Brushes.Black))
            {
                this.but1.Foreground = (Brushes.White);
            }
            else
            {
                this.but1.Foreground = (Brushes.Black);
            }
        }
        //End Button Styling
    }
}