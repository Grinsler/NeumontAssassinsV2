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

namespace NeumontAssassinV2.Missions
{
    /// <summary>
    /// Interaction logic for DrugLord.xaml
    /// </summary>
    public partial class DrugLord : UserControl
    {
       //Player pp = new Player();

        public DrugLord()//Player p)
        {
            InitializeComponent();
            //pp = p;
        }
        int counter = 0;
        int choiceCounter = 1;
        int userchoice = 0;

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
                        choice1();
                        break;
                    case 2:
                        choice2();
                        break;
                }
                
                choiceCounter++;
            }
            
        }

        public void choice1()
        {
            testLabe2.Content = "What shoul I pick...";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Rock";
            but2.Content = "Paper";
            but3.Content = "Scissors";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
            but3.Visibility = Visibility.Visible;
            

        }

        public void choice2()
        {
            testLabe2.Content = "...";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Kill him";
            but2.Content = "Just Kidding";
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
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
    }
}