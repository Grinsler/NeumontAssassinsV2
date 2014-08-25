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
using System.Windows.Media.Animation;
using NeumontAssassinV2.ScreenControls;

namespace NeumontAssassinV2.Missions
{
    /// <summary>
    /// Interaction logic for DrugLord.xaml
    /// </summary>
    public partial class DrugLord : UserControl
    {
        //hello        
        GameState load = new GameState();
        public Person player = new Person();
        public Random rand = new Random();                      

        Uri imgsrc;
        BitmapImage bmp;

        int counter = 0;
        int choiceCounter = 1;
        int userchoice = 0;
        int faultCounter = 0;

        private void New_Click_1(object sender, RoutedEventArgs e)
        {
            //create a new person and delete the old one from the file.
        }

        private void Continue_Click_1(object sender, RoutedEventArgs e)
        {
            load.LoadUser();
            load.LoadWeek();
            //I need to then go to the weekly trainning xaml.
        }

        private void Exit_Click_1(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public DrugLord(Person p)
        {
            InitializeComponent();
            player = p;
        }

        #region Dialogue
        public List<string> logs = new List<string>
        {
            //backgroud info
            "Cevon: Good, you made it. Your first target is a local drug dealer. \nHe and his gang have been causing trouble for our agents operating in the area.",
            "Cevon: They’re just common rabble really. \nYour mission is to take out the dealer, and any of his thugs if necessary.",
            "Cevon: Take out the dealer: it can’t be any simpler than that",
            "Cevon: Down by 1337 street, in the back alley of Path and Exile.",
            "Player: Affirmative.",
            "Cevon: “Get going then.",
            "Player: This is it. I can’t afford to mess this up..",
            
            //-------------dumpster choice--------------------------------------------
            "Choice",
            //agility Path==============
            //agility success Starts: Index 8
            "Thats right, I should utilize my athleticism here.",
            "I swiftly scaled over the dumpster and over the fence, landing down into the construction site. \nLuck it’s Sunday, so the workers are all at home. I have to make my way to the other side of the site and climb over that fence blocking the main street...",
            "Ahh, no one seemed to notice.",
            /*Jump to line*/"Line_28",
            //agility fail Starts: Index 12
            "Argh, I definitely botched that jump - leg hurts… Shouldn’t be too much trouble once I get past the gate.",
            "That didn’t go as planned... Hope no one noticed me...",
            /*Jump to line*/"Line_28",

            //fight path=================
            //fight success Starts: Index 15
            "Player: Sorry you gonna have to move bud... *PUNCH*",
            "HAHAHA, floored 'im, good thing I spent so much time building my muscles. \nGuy didn’t even know what was coming.",
            /*Jump to line*/"Line_28",
            //fight fail Starts: Index 18
            "Player: Let see what you got... HIIYAA",
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
            "The guard blocks your punch and nails you right in the gut. \nThankfully, before he can get off another blow,\n you are able to slip passed him. \n But they may be alerted now...",
            /*Jump to line*/"Line_28",

            //---------1st attack chance--------------
            //Starts: Index 28
            "There he is! The Druglord..",
            "My target, the dealer, is right there walking with another gangmember. \nI don’t think they’ve noticed me yet.",
            "Choice",//go to choice_1stKillChance

            //Attack Path===========
            //attack success Starts: index 31
            "I moved like lightning. All this training has payed off",
            "I lifted my knife to the man on the right’s neck and raised my \nsilenced pistol to the base of the dealer’s head all within a fraction of a second",
            "My knife moved smoothly across the mans neck making quick work \nof him as I pulled the gun trigger in my left hand.",
            "I felt my bullet find its mark (Its kinda hard to miss from this close)",
            "They both fell to the ground, \nbut I did not have time to stand around and admire my handiwork",
            "Now I can head back to HQ without a hitch",
            "END",
            //attack fail and death Starts: index 38
            "What the-?!... I slipped...",
            "Your mission has been compromised and you have been killed",
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
            "Choice","","", //choice4_Faults0

            //rush success Line 49
            "*SLICE* \nHmm... \nThat was easier than I was expecting. One knife to the throat and he was done for. \nWell, better head back to base.",
            "END",

            //rush fail Line 51
            "Player: HIYAA...",
            "Druglord: HAHAHA, too slow!",
            "The Druglord and his minions jump and incapacitate you.",
            "Your mission has been compromised and you have been killed",
            "DEAD",

            //Walk up Path ================== Line 56
            "Good, he doesn't notice me.",
            "Choice", //choice5_HowToKill

            //AGIL kill line 58
            "Your hand moves to your dagger and in the blink of a eye the blade is unshethed and finds its taget,",
            "Embedded deep into the druglords chest.",
            "Player: Keep the change.",
            "END",
            //STR kill line 62
            "Bofore he could move, you grab his head with both hands and slammed it onto the wall as hard as you can.",
            "*HRAAGGH*",
            "Player: That finished the job. Better head back.",
            "END",
            //CHA kill line 66
            "Player: Look man, selling drugs isn't something you should be doin. Youre better than that.",
            "Druglord: Look I dont need you tellin' me how to live my life.",
            "Player: Just saying, one day you may end up dyin for it...",
            "Druglord: Well I'll deal with who ever want to kill me when that day com...",
            "*gurgle* \nYour knife finds the druglord's throat.",
            "Player: Should have listened to me...",
            "Player: Time to head back",
            "END",
            //INT kill line 74
            "You pull out you silenced pistol and place it against the druglord's head. He's too stunned to move.",
            "*PPCCKK*... He collapses against the wall.",
            "Player: Sorry, you just got put out of bussiness.",
            "END"
            
        };
        #endregion

        //Methods to change the background:
        #region BackgroundChanges
        private void ImageFadeOut_Completed_Secretary(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/secretary.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeInSec = new Storyboard();
            DoubleAnimation FadeInSec = new DoubleAnimation();
            FadeInSec.From = 0.0;
            FadeInSec.To = 1.0;
            FadeInSec.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeInSec.Children.Add(FadeInSec);
            Storyboard.SetTargetName(FadeInSec, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeInSec, new PropertyPath(Image.OpacityProperty));
            SFadeInSec.Begin(this);
        }
        private void ImageFadeOut_Completed_HQ(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Front of Building.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeInSec = new Storyboard();
            DoubleAnimation FadeInSec = new DoubleAnimation();
            FadeInSec.From = 0.0;
            FadeInSec.To = 1.0;
            FadeInSec.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeInSec.Children.Add(FadeInSec);
            Storyboard.SetTargetName(FadeInSec, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeInSec, new PropertyPath(Image.OpacityProperty));
            SFadeInSec.Begin(this);
        }
        private void ImageFadeOut_Completed_MainMenu(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/MainMenuBack.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeInSec = new Storyboard();
            DoubleAnimation FadeInSec = new DoubleAnimation();
            FadeInSec.From = 0.0;
            FadeInSec.To = 1.0;
            FadeInSec.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeInSec.Children.Add(FadeInSec);
            Storyboard.SetTargetName(FadeInSec, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeInSec, new PropertyPath(Image.OpacityProperty));
            SFadeInSec.Begin(this);
        }
        private void ImageFadeOut_Completed_AngryJames(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/AngryJames.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;                                                       
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_CharsmaSuccess(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/CharsmaSuccess.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;                                                       
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DeadJames(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DeadJames.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;                                                       
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DexerityJump(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DexerityJump.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;                                                       
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordAndFriend(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordAndFriend.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordAndFriendDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordAndFriendDead.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordAndFriendSeperate(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordAndFriendSeperate.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordAppear(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordAppearance.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordDead.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordKnows(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordKnows.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordSuprised(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordSuprised.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordUncertain(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordUncertain.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_DrugLordUnspecting(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/DrugLordUnspecting.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_Dumpser(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/Dumpster.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_FightMe(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/FightMe.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        private void ImageFadeOut_Completed_YouAreDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/YouAreDead.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        #endregion

        //================================CycleDialogue==================================
        private void CycleDialogue(object sender, MouseButtonEventArgs e)
        {
            
            if (logs[counter].Equals("Line_28"))
            {
                Storyboard SFadeOutLine28 = new Storyboard();
                DoubleAnimation FadeOut28 = new DoubleAnimation();
                SFadeOutLine28.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordAndFriend);
                FadeOut28.From = 1.0;
                FadeOut28.To = 0.0;
                FadeOut28.Duration = new Duration(TimeSpan.FromSeconds(.5));
                SFadeOutLine28.Children.Add(FadeOut28);
                Storyboard.SetTargetName(FadeOut28, TheBackground.Name);
                Storyboard.SetTargetProperty(FadeOut28, new PropertyPath(Image.OpacityProperty));

                SFadeOutLine28.Begin(this); 
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
            //===============================================
            #region regularTextPictreChange
            //MAKE CEVON APEAR AT INDEX 0
            else if (logs[counter].Equals(logs[0]) || logs[counter].Equals(logs[76]))
            {
                Storyboard start = new Storyboard();
                DoubleAnimation startfade = new DoubleAnimation();
                start.Completed += new EventHandler(ImageFadeOut_Completed_Secretary);
                startfade.From = 1.0;
                startfade.To = 0.0;
                startfade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                start.Children.Add(startfade);
                Storyboard.SetTargetName(startfade, TheBackground.Name);
                Storyboard.SetTargetProperty(startfade, new PropertyPath(Image.OpacityProperty));

                start.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }

            else if (logs[counter].Equals(logs[15]))
            {
                Storyboard str1pic = new Storyboard();
                DoubleAnimation FadeOutstr1 = new DoubleAnimation();
                str1pic.Completed += new EventHandler(ImageFadeOut_Completed_AngryJames);
                FadeOutstr1.From = 1.0;
                FadeOutstr1.To = 0.0;
                FadeOutstr1.Duration = new Duration(TimeSpan.FromSeconds(.5));
                str1pic.Children.Add(FadeOutstr1);
                Storyboard.SetTargetName(FadeOutstr1, TheBackground.Name);
                Storyboard.SetTargetProperty(FadeOutstr1, new PropertyPath(Image.OpacityProperty));

                str1pic.Begin(this); 

                testLabel.Content = logs[counter];
                counter++;
            }

            else if (logs[counter].Equals(logs[16]))
            {
                Storyboard str2pic = new Storyboard();
                DoubleAnimation FadeOutstr2 = new DoubleAnimation();
                str2pic.Completed += new EventHandler(ImageFadeOut_Completed_DeadJames);
                FadeOutstr2.From = 1.0;
                FadeOutstr2.To = 0.0;
                FadeOutstr2.Duration = new Duration(TimeSpan.FromSeconds(.5));
                str2pic.Children.Add(FadeOutstr2);
                Storyboard.SetTargetName(FadeOutstr2, TheBackground.Name);
                Storyboard.SetTargetProperty(FadeOutstr2, new PropertyPath(Image.OpacityProperty));

                str2pic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            
            else if (logs[counter].Equals(logs[18]) || logs[counter].Equals(logs[24]) )
            {
                Storyboard str2pic = new Storyboard();
                DoubleAnimation FadeOutstr2 = new DoubleAnimation();
                str2pic.Completed += new EventHandler(ImageFadeOut_Completed_FightMe);
                FadeOutstr2.From = 1.0;
                FadeOutstr2.To = 0.0;
                FadeOutstr2.Duration = new Duration(TimeSpan.FromSeconds(.5));
                str2pic.Children.Add(FadeOutstr2);
                Storyboard.SetTargetName(FadeOutstr2, TheBackground.Name);
                Storyboard.SetTargetProperty(FadeOutstr2, new PropertyPath(Image.OpacityProperty));

                str2pic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[21]) )
            {
                Storyboard charPic = new Storyboard();
                DoubleAnimation charFade = new DoubleAnimation();
                charPic.Completed += new EventHandler(ImageFadeOut_Completed_CharsmaSuccess);
                charFade.From = 1.0;
                charFade.To = 0.0;
                charFade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                charPic.Children.Add(charFade);
                Storyboard.SetTargetName(charFade, TheBackground.Name);
                Storyboard.SetTargetProperty(charFade, new PropertyPath(Image.OpacityProperty));

                charPic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[31]))
            {
                Storyboard str2pic = new Storyboard();
                DoubleAnimation FadeOutstr2 = new DoubleAnimation();
                str2pic.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordAndFriendDead);
                FadeOutstr2.From = 1.0;
                FadeOutstr2.To = 0.0;
                FadeOutstr2.Duration = new Duration(TimeSpan.FromSeconds(.5));
                str2pic.Children.Add(FadeOutstr2);
                Storyboard.SetTargetName(FadeOutstr2, TheBackground.Name);
                Storyboard.SetTargetProperty(FadeOutstr2, new PropertyPath(Image.OpacityProperty));

                str2pic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if(logs[counter].Equals(logs[38]))
            {
                Storyboard DeathPic = new Storyboard();
                DoubleAnimation DeathFade = new DoubleAnimation();
                DeathPic.Completed += new EventHandler(ImageFadeOut_Completed_YouAreDead);
                DeathFade.From = 1.0;
                DeathFade.To = 0.0;
                DeathFade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                DeathPic.Children.Add(DeathFade);
                Storyboard.SetTargetName(DeathFade, TheBackground.Name);
                Storyboard.SetTargetProperty(DeathFade, new PropertyPath(Image.OpacityProperty));

                DeathPic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[41]))
            {
                Storyboard DeathPic = new Storyboard();
                DoubleAnimation DeathFade = new DoubleAnimation();
                DeathPic.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordAndFriendSeperate);
                DeathFade.From = 1.0;
                DeathFade.To = 0.0;
                DeathFade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                DeathPic.Children.Add(DeathFade);
                Storyboard.SetTargetName(DeathFade, TheBackground.Name);
                Storyboard.SetTargetProperty(DeathFade, new PropertyPath(Image.OpacityProperty));

                DeathPic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[43]))
            {
                Storyboard DeathPic = new Storyboard();
                DoubleAnimation DeathFade = new DoubleAnimation();
                DeathPic.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordUncertain);
                DeathFade.From = 1.0;
                DeathFade.To = 0.0;
                DeathFade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                DeathPic.Children.Add(DeathFade);
                Storyboard.SetTargetName(DeathFade, TheBackground.Name);
                Storyboard.SetTargetProperty(DeathFade, new PropertyPath(Image.OpacityProperty));

                DeathPic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[49]) || logs[counter].Equals(logs[58]) || logs[counter].Equals(logs[62]) || logs[counter].Equals(logs[66]) || logs[counter].Equals(logs[74]))
            {
                Storyboard DeathPic2 = new Storyboard();
                DoubleAnimation DeathFade2 = new DoubleAnimation();
                DeathPic2.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordDead);
                DeathFade2.From = 1.0;
                DeathFade2.To = 0.0;
                DeathFade2.Duration = new Duration(TimeSpan.FromSeconds(.5));
                DeathPic2.Children.Add(DeathFade2);
                Storyboard.SetTargetName(DeathFade2, TheBackground.Name);
                Storyboard.SetTargetProperty(DeathFade2, new PropertyPath(Image.OpacityProperty));

                DeathPic2.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[51]))
            {
                Storyboard DeathPic = new Storyboard();
                DoubleAnimation DeathFade = new DoubleAnimation();
                DeathPic.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordKnows);
                DeathFade.From = 1.0;
                DeathFade.To = 0.0;
                DeathFade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                DeathPic.Children.Add(DeathFade);
                Storyboard.SetTargetName(DeathFade, TheBackground.Name);
                Storyboard.SetTargetProperty(DeathFade, new PropertyPath(Image.OpacityProperty));

                DeathPic.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            //=============================================
            else if (logs[counter].Equals("Choice"))
            {
                testLabel.Visibility = Visibility.Hidden;
                switch (choiceCounter)
                {
                    case 1:
                        Storyboard SFadeOut = new Storyboard();
                        DoubleAnimation FadeOut = new DoubleAnimation();
                        SFadeOut.Completed += new EventHandler(ImageFadeOut_Completed_Dumpser);
                        FadeOut.From = 1.0;
                        FadeOut.To = 0.0;
                        FadeOut.Duration = new Duration(TimeSpan.FromSeconds(.5));
                        SFadeOut.Children.Add(FadeOut);
                        Storyboard.SetTargetName(FadeOut, TheBackground.Name);
                        Storyboard.SetTargetProperty(FadeOut, new PropertyPath(Image.OpacityProperty));

                        SFadeOut.Begin(this);                        

                        choice1_Dumpster();
                        break;
                    case 2:
                        choice2_Kill_Or_Wait();
                        break;
                    case 3:
                        Storyboard SFadeOut3 = new Storyboard();
                        DoubleAnimation FadeOut3 = new DoubleAnimation();
                        SFadeOut3.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordUnspecting);
                        FadeOut3.From = 1.0;
                        FadeOut3.To = 0.0;
                        FadeOut3.Duration = new Duration(TimeSpan.FromSeconds(.5));
                        SFadeOut3.Children.Add(FadeOut3);
                        Storyboard.SetTargetName(FadeOut3, TheBackground.Name);
                        Storyboard.SetTargetProperty(FadeOut3, new PropertyPath(Image.OpacityProperty));
                        choice3_Faults1();
                        break;
                    case 4:
                        Storyboard SFadeOut4 = new Storyboard();
                        DoubleAnimation FadeOut4 = new DoubleAnimation();
                        SFadeOut4.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordAndFriend);
                        FadeOut4.From = 1.0;
                        FadeOut4.To = 0.0;
                        FadeOut4.Duration = new Duration(TimeSpan.FromSeconds(.5));
                        SFadeOut4.Children.Add(FadeOut4);
                        Storyboard.SetTargetName(FadeOut4, TheBackground.Name);
                        Storyboard.SetTargetProperty(FadeOut4, new PropertyPath(Image.OpacityProperty));

                        choice4_Faults0();
                        break;
                    case 5:
                         Storyboard SFadeOut5 = new Storyboard();
                        DoubleAnimation FadeOut5 = new DoubleAnimation();
                        SFadeOut5.Completed += new EventHandler(ImageFadeOut_Completed_DrugLordSuprised);
                        FadeOut5.From = 1.0;
                        FadeOut5.To = 0.0;
                        FadeOut5.Duration = new Duration(TimeSpan.FromSeconds(.5));
                        SFadeOut5.Children.Add(FadeOut5);
                        Storyboard.SetTargetName(FadeOut5, TheBackground.Name);
                        Storyboard.SetTargetProperty(FadeOut5, new PropertyPath(Image.OpacityProperty));

                        SFadeOut5.Begin(this);

                        choice5_HowToKill();
                        break;
                }
                choiceCounter++;
            }

            //else if()
            //{

            //}
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
        /// <summary>
        /// Demo end of mission FIX LATER
        /// </summary>
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

        /// <summary>
        /// DEMO DEATH FIX LATER
        /// </summary>
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
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
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

        //==============button enter=====================
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

    }
}