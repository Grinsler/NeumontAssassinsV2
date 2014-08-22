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
        public Person player = new Person();
        public Random rand = new Random();

        int counter = 0;
        int choiceCounter = 1;
        int userchoice = 0;
        int faultCounter = 0;

        public DrugLord(Person p)
        {
            InitializeComponent();
            player = p;
        }
        

        #region Dialogue
        public List<string> logs = new List<string>
        {
            //backgroud info
            "Cevon: Good, you made it. Your first target is a local drug dealer. He and his gang have been causing trouble for our agents operating in the area.",
            "Cevon: They’re just common rabble really. Your mission is to take out the dealer, and any of his thugs if necessary.",
            "Cevon: Take out the dealer: it can’t be any simpler than that",
            "Cevon: Down by 1337 street; in the back alley of Path and Exile.",
            "Player: Affirmative.",
            "Cevon: “Get going then.",
            "Player: This is it. I can’t afford to mess this up..",
            
            //-------------dumpster choice---------------
            "Choice",
            //agility Path==============
            //agility success Starts: Index 8
            "Thats right, I should utilize my athleticism here.",
            "I swiftly scaled over the dumpster and over the fence, landing down into the construction site. \nIt’s Sunday, so the workers are all at home. I have to make my way to the other side of the site and climb over the fence blocking the main street...",
            "Luckily no one seemed to notice.",
            /*Jump to line*/"Line_28",
            //agility fail Starts: Index 12
            "Argh, I definitely botched that jump - leg hurts… Shouldn’t be too much trouble once I get past the gate.",
            "That didn’t go as planned... Hope no one noticed me.",
            /*Jump to line*/"Line_28",

            //fight path=================
            //fight success Starts: Index 15
            "Player: Sorry you gonna have to move bud... *PUNCH*",
            "HAHA floored 'im, good thing I spent so much time building my muscles. \nGuy didn’t even know what was coming.",
            /*Jump to line*/"Line_28",
            //fight fail Starts: Index 18
            "Let see whar you got... HIIYAA",
            "The guard blocks your punches and knocks you in the stomach. \nThankfully, before he can finish the job, you are able to run passed him. They may be alerted now...",
            /*Jump to line*/"Line_28",

            //talk Path==================
            //talk success Starts: Index 21
            "Player: Look, I don’t want any trouble son, *flex*, just let me pass and there won't be any... \"accidents\".",
            "Gang member: Alright, alright. You can pass, man. I don't want no trouble...",
            /*Jump to line*/"Line_28",
            //talk fail Starts: Index 24
            "Look, I don’t want any trouble man, just let me pass alright?",
            "Gang member: I don’t think so, you’re not goin’ anywhere, chump!",
            "The guard blocks your punches and punches you right in the gut. \nThankfully, before he can get off another blow, you are able to slip passed him. They may be alerted now...",
            /*Jump to line*/"Line_28",

            //---------1st attack chance--------------
            //Starts: Index 28
            "There he is! The Druglord..",
            "My target, the dealer, is right there walking with another gangmember. I don’t think they’ve noticed me yet.",
            "Choice",//go to choice_1stKillChance

            //Attack Path===========
            //attack success Starts: index 31
            "I moved like lightning. All this training has payed off",
            "I lifted my knife to the man on the right’s neck and raised my silenced pistol the the base of the dealer’s head all within a fraction of a second",
            "My knife moved smoothly across the mans neck making quick work of him as I pulled the trigger in my left hand.",
            "I felt my bullet find its mark (Its kinda hard to miss from this close)",
            "They both fell to the ground, but I did not have time to stand around and admire my handiwork",
            "I headed back to HQ without a another hitch",
            "END",
            //attack fail and death Starts: index 38
            "What the-?!... I slipped...",
            "Your mission has been compromised and you have been killed [Click to return to the beginning of the mission]",
            "DEAD",
             
            //Wait Path(dealer on his own) index 41===========
            "Thats right, I should wait for the other man to leave...",
            "FaultCheck",
            //change scene
            
            //Fault + 1 Starts: index 43
            "Uh-oh, I think the dealer is expecting me. Oh well, guess I should try taking him by surprise.",
            "Choice", //choice3_Faults1

            //Fault = 0 line 45
            "I could Rush him here or I could walk up like a customer...",
            "Choice", //choice4_Faults0

            //Rush Path=============
            //line 47
            "Player: Lets go!",
            "rush_check",

            //rush success Line 49
            "*SLICE* \nHm. He was frailer than I was expecting. One knife to the throat and he’s done for. \nWell, better head back to base.",
            "END",

            //rush fail Line 51
            "Player: HIYAA...",
            "Druglord: HAHA too slow",
            "The Druglord and his minions jump you.",
            "Your mission has been compromised and you have been killed [Click to return to the beginning of the mission]",
            "DEAD",

            //Walk up Path ================== Line 56
            "Good, he doesn't notice me.",
            "Choice", //choice5_HowToKill

            //AGIL kill line 58
            "Your hand moves to you dagger and in the blink of a eye you blade is unshethed and finds its taget,",
            "deep in the druglords chest.",
            "Player: Keep the change.",
            "END",
            //STR kill line 62
            "Bofore he could move, you grab his head with both hands and slammed it onto the wall as hard as you can.",
            "*HRAAGGH*",
            "Player: That finished the job. Better head back.",
            "END",
            //CHA kill line 66
            "Player: Look man, selling drugs isn't something you should be doin. Youre better than that.",
            "Druglord: Look i dont need you tellin me how to live my life.",
            "Player: Just saying, one day you may end up dyin for it...",
            "Druglord: Well I'll deal with who ever want to kill me when that day com...",
            "Your knife finds the druglord's throat.",
            "Player: Should have listened to me...",
            "Player: Time to head back",
            "END",
            //INT kill line 74
            "You pull out you silenced pistol and place it against the druglord's head. He's too stunned to move.",
            "*PEW*... He collapses against the wall.",
            "Player: Sorry, you just got put out of bussiness.",
            "END"
            
        };
        #endregion

        //================================CycleDialogue==================================
        private void CycleDialogue(object sender, MouseButtonEventArgs e)
        {
            if (logs[counter].Equals("Line_28"))
            {
                counter = 28;
            }
            else if (logs[counter].Equals("END"))
            {
                end();
            }
            else if (logs[counter].Equals("FaultCheck"))
            {
                faultCheck();
            }
            else if (logs[counter].Equals("DEAD"))
            {
                death();
            }

            if (logs[counter].Equals("Choice"))
            {
                testLabel.Visibility = Visibility.Hidden;
                switch (choiceCounter)
                {
                    case 1:
                        choice1_Dumpster();
                        break;
                    case 2:
                        choice2_Kill_Or_Wait();
                        break;
                    case 3:
                        choice3_Faults1();
                        break;
                    case 4:
                        choice4_Faults0();
                        break;
                    case 5:
                        choice5_HowToKill();
                        break;
                }
                choiceCounter++;
            }
            // Regular dialogue 
            else
            {
                testLabel.Content = logs[counter];
                counter++;
            }
            
        }
        //================================Choices==================================
        public void choice1_Dumpster()
        {
            testLabe2.Content = "Hmm, how should I go about this ... ";
            testLabe2.Visibility = Visibility.Visible;
            if (player.Player_Agility >= 5)
            {
                but1.Content = "Jump the dumpster and avoid the Gangmember";
                but1.Visibility = Visibility.Visible;
            }
            
            but2.Content = "Confront the gang member";
            but3.Content = "Persuade the gang member";
            
            but2.Visibility = Visibility.Visible;
            but3.Visibility = Visibility.Visible;    

        }

        public void choice2_Kill_Or_Wait()
        {
            testLabe2.Content = "What should i do?...";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Attack them";
            but2.Content = "Wait";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
        }
        public void choice3_Faults1()
        {
            testLabe2.Content = "Drugload: You buying?";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "No. You’re buying. A one-way ticket to deadville. \nPopulation: You";
            but2.Content = "Yeah. How much are you charging";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
        }

        public void choice4_Faults0()
        {
            testLabe2.Content = "Hmm...";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Rush him now!";
            but2.Content = "Walk up to get closer";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
        }

        

        public void choice5_HowToKill()
        {
            testLabe2.Content = "I know what i have to do?";
            testLabe2.Visibility = Visibility.Visible;
            

            if (player.Player_Agility > 5)
            {
                but1.Content = "Knife him";
                but1.Visibility = Visibility.Visible;
            }
            if(player.Player_Intellegence > 5)
            {
                but2.Visibility = Visibility.Visible;
                but2.Content = "Quickly pull out a silenced pistol and shoot him in the head";
            }

            if (player.Player_Strength > 5)
            {
                but3.Visibility = Visibility.Visible;
                but3.Content = "Slam him against the back of the wall and crack his skull open";
            }
            if (player.Player_Charisma > 5)
            {
                but4.Visibility = Visibility.Visible;
                but4.Content = "Convince him to quit selling drugs, then kill him while he’s unaware";
            }
        }
        public void end()
        {
            testLabe2.Content = "END";
            testLabel.Visibility = Visibility.Hidden;
            testLabe2.Visibility = Visibility.Visible;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            
        }

        public void faultCheck()
        {
            if (faultCounter == 0)
            {
                counter = 45;
                choiceCounter = 4;
                userchoice++;
            }
            else
            {
                counter = 43;
                choiceCounter = 3;
            }
        }

        public void death()
        {
            counter = 0;
            faultCounter = 0;
            userchoice = 0;
            choiceCounter = 1;
        }
        //===================--Buttons--===============================================
        private void but1_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 0:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        counter = 8;
                    }
                    else
                    {
                        counter = 12;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
                case 1:
                    if (rand.Next(0, 10) >= 5)
                    {
                        counter = 31;
                    }
                    else
                    {
                        counter = 38;
                    }
                    userchoice++;
                    break;
                case 2:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        counter = 49;
                    }
                    else
                    {
                        counter = 51;
                    }
                    userchoice++;
                    break;
                case 3:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        counter = 49;
                    }
                    else
                    {
                        counter = 51;
                    }
                    userchoice++;
                    break;
                case 4:
                    counter = 58;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
            
        }

        private void but2_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 0:
                    if (player.Player_Strength + rand.Next(0, 10) >= 10)
                    {
                        counter = 15;
                    }
                        
                    else
                    {
                        counter = 18;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
                case 1:
                    counter = 41;
                    userchoice++;
                    break;
                case 2:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        counter = 49;
                    }
                    else
                    {
                        counter = 51;
                    }
                    userchoice++;
                    break;
                case 3:
                    counter = 56;
                    userchoice++;
                    break;
                case 4:
                    counter = 74;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }

        private void but3_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 0:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                        counter = 21;
                    else
                    {
                        counter = 24;
                        faultCounter++;
                    }


                    userchoice++;
                    break;
                case 4:
                    counter = 62;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }

        private void but4_choice(object sender, RoutedEventArgs e)
        {
            switch (userchoice)
            {
                case 4:
                    counter = 66;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = logs[counter];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }
    }
}