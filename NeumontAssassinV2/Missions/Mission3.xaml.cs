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
    /// Interaction logic for Mission3.xaml
    /// </summary>
    public partial class Mission3 : UserControl
    {
        public Person player = new Person();
        public Random rand = new Random();                      

        Uri imgsrc;
        BitmapImage bmp;

        int counter = 0;
        int choiceCounter = 1;
        int userchoice = 0;
        int faultCounter = 0;

        public Mission3(Person p)
        {
            InitializeComponent();
            player = p;
        }

#region Dialogue
        public List<string> logs = new List<string>
        {
            #region introtext
            "Cevon: I hope you feel confident after that last mission.",
            "Player: After what I’ve done? I can take anything you can give me.",
            "Cevon: Confidence, or recklessness? \nEither way you’ll need one of those for this next mission.",
            "Player: ...",
            "Cevon: You’ll be taking out... The vice president‘s son",
            "You’ve gotta be kidding me.",
            "Player: What!? There has to be a crazy security around him at all times",
            "Cevon: Most of the time that’s true, \nbut he’s coming to Salt Lake on a business trip this Sunday \nand he’s staying at a hotel on the top floor with a very limited security detail.",
            "Why is it always the top floor?",
            "Player: And when he goes back to his room will be the perfect time to strike. I see.",
            "Cevon: We also got some intel that says that there is a locked door \nin the back of the building where there will be no security. \nI was thinking you might be able to pick it if you have the aptitude",
            "Player: I see. I’ll think about it.",
            "Cevon: This mission will also involve some international guards, \nI know you are fluent in most languages but you might want to work on \nbeing comfortable talking in them.",
            "Player: That might be a good idea too.",
            "Cevon: Good you understand. Infiltrate the hotel and take him out. \nHe should not be on high alert, but hes security will be. \nSo go, execute order 66.",
            "Player: It will be done, my lord.",
            "Cevon: We’re hopeless...",
            "Player: ...",
            "Reference isn’t even from the original trilogy? I’m ashamed.",
            "Player: So, the vice president’s son huh?",
            "If I can do this, I can do any mission they throw at me.",
            #endregion
            //scene change
            "Better make my way to the target location.",
            "Where should I start? I could try and sneak into the side entrance, \nbut there are a couple of guards around that area. \nI could look for a lock to pick in the back of the building and get in without risk of \nbeing seen, but can I pick the lock fast enough?",
            //==============================-- Choice 1 (Line 23) --=====================================
            "Choice",
            //=====-- Agility Path 24 --=====
            #region AGL 24
            //---------Pass 24--------
            "Player: Right, I should sneak in.",
            "I moved from cover to cover and made it past the guards like a knife through butter",
            "Just as I thought: the side door isn’t locked. \nI guess the guards are constantly going in and out.",
            "As I step inside I am greeted with an elevator and a stairwell.",
            "To_Line57",
            //---------Fail 29--------
            "Alright lets sneak...  ",
            "haha too eas... *CLANG!*",
            "What was that…?",
            "Crap! I kicked a soda can. How could I be so careless?!",
            "The guards are starting to make their way over here. \nI have to get in NOW!",
            "Good thing the door is unlocked or I’d be done for.",
            "To_Line57",
            #endregion
            //===-- Inteligence Path 36 --===
            #region INT 36
            //---------Pass 36--------
            "Player: I can definitely pick that lock.",
            "This was definitely a good choice. No guards in sight.",
            "And there’s the door. Just like the intel said.",
            "Player: Now I just slip my tool in here… Turn like this… Aaaaaand...",
            "Player: Yes, its open!",
            "Player: That couldn’t have gone more perfectly.\nJust ahve to make my way to the elevator or the stairway now.",
            "To_Line57",
            //---------Fail 43--------
            "Player: I can definitely pick that lock.",
            "This was definitely a good choice. No guards in sight.",
            "And there’s the door. Just like the intel said.",
            "Player: Now I just slip my tool in here… Turn like this… Aaaaaand...",

            "Wait maybe I turned it the wrong way?",
            "...",
            "Urrgh, this is taking too long!",
            "Guard 1: I gotta take a leek. Goin around to the back.",
            "Guard 2: Alright don’t take too long",
            "Gaah, I need to get this open now!",
            "Twist right… Left… Jerk up... Thennnn… Out!  YES!",
            "I made it is just in time. \nI just hope he didn't see or hear the door close.",
            "I have to make my way to the elevator or the stairway now.",
            "To_Line57",
            #endregion
            //=======-- Continue 57 --=======
            "Thoughts: Hmmm… I should take the stairs because its easier to maneuver in there, \nbut the elevator is faster and I could save energy, \nbut I could bump into someone inside.",
            "Thoughts: This is risky.",
            //==============================-- Choice 2 (Line 59) --=====================================
            "Choice",
            //=====-- Agility Path 60 --=====
            #region AGL 60
            //Pass 60
            "Stairs are definitely the better choice.",
            "Climbing these stairs is easier than I thought it’d be!",
            "Player: Just gotta keep moving. Almost there.",

            "*step* *step* *step*",

            "Someone is coming down? This makes things more fun. Ha!",
            "I have to get out of sight.",
            "I’ll use the stairs above me!",
            "I’ll grab on to the bottom side of the stairs \nand he’ll just pass right under me",
            "Player: hmph",
            //(Jumps and grabs the top of the stairs)
            "*staaaaare*",
            //(Guard Passes by)
            "Just as planned.",
            "*Thump*",
            //(Lands Back on the ground)
            "This mission is as good as cleared",
            "To_Line134",
            #endregion
            #region AGL 74
            //Fail 74
            "Stairs are definitely the better choice.",
            "Climbing these stairs is gonna be easy...",
            "Player: How much longer...",
            "My breathing is getting louder, am I really not in shape?...",
            "Player: Haa… Haa… Haa...",
            "*step* *step* *step*",
            "Someone’s coming down!",
            "I have to get out of sight!",
            "The stairs above!",
            "If I can grab on to the bottom side of the stairs, \nhe’ll just pass right under me.",
            "Player: *hup*",
            "I just have to hold on long enou-",
            "*Slip*",
            "I’m… falling?...",
            "*crash*",
            "Player: Uuugghh!",

            "I blinked a few times… The man was bearing down on me.",
            "*PUNCH* *KICK* *POW*",
            "Your mission has been compromised and you have been killed",
            "DEAD",
            #endregion
            //=====-- Charisma Path 94 --====
            #region CHA 94
            //Pass 94
            "I’ll take the elevator. It’s way more efficient.",
            "*click*",
            "And now I play the waiting game, and not those accounting games...",
            "*ding*",
            "It’s here. Now just gotta ride it to the t…",
            //(person in the elevator)
            "……mother...!!!",
            "I’ll have to talk my way out of this one…",
            "Guard: Anata wa koko de nani o shite ka? \n(What are you doing here?)",
            "Thoughts: Japanese? I can definitely talk past this guy. \nHaha, I can finally put all that anime I watched to good use!",
            "Player: Watashi wa patorōru no gozen. \n(I’m on standard patrol.)",
            "Guard: Rikai suru. \n(Understood.)",
            "Player: Anata ga kyūkei ni ari? \n(Are you on break?)",
            "Guard: Hai \n(Yes.)",
            "Player: Sō ka. Sō ka. Amari nonde wa ikenai, ne? Hahahaha \n(I see I see, don’t drink too much okay? Hahaha.)",
            "Guard: HaHaHa, Hai, Hai. Jā ne. \n(Ha Ha Ha Yea yea. See you later.)",
            "Thoughts: That was close… \nNow if I hold the ‘door close’ button then it’ll be smooth sailing to the top",
            "To_Line134",
            #endregion
            #region CHA 111
            //Fail 111
            "I’ll take the elevator. It’s way more efficient.",
            "*click*",
            "And now I play the waiting game, and not those accounting games...",
            "*ding*",
            "It’s here. Now just gotta ride it to the t…",
            //(person in the elevator)
            "……mother ffffffff-!!!",
            "I’ll have to talk my way out of this one…",
            "Guard: Anata wa koko de nani o shite ka? \n(What are you doing here?)",
            "Japanese? Well, I did watch a lot of anime in the past… \nWe’ll see how much i remember.",

            "Player: Wa-Wa-Watashi wa patorōru no gozen \n(I-I-I’m on standard patrol.)",

            "Guard: Nanika ga machigatte iru \n(Is something wrong)",

            "uhhh… What did he say?",

            "Player: Etoooo… \n(Uhhh...)",
            "The guard is getting more suspicious.",
            "Guard: Dare ka?! (Who are you?!)",
            "...I can’t do this.",
            "Player: Sempai, Onegai...\n(???)",
            "Player: daisuki \n(...)",

            "Guard: Eeeeh? Anata wa nani o itte iru \n(Eh what are you doing?)",
            "No…",
            "Guard: bakayaro, konoyaro!! Shinu!! \n(Dumbass! Die!!)",

            "*SLICE* *SLICE*... you have been killed by a switchblade comb... nice job",
            "DEAD",
            #endregion
            //=======-- Continue 134 --======
            //[Top Floor Scene]
            "Player: ...",
            "Top floor…",
            "There’s the room… Two guards… fun.",
            "Choice",

            //====-- Strength Path 138 --====
            #region STR 138
            //Pass (unfailable)
            "That bin filled with bricks will be perfect",
            //(picture of picking up crate)
            "Ha, the rest is easy. Just gotta throw it...",
            "Player: Hrraaaaaagh!",
            "*Crunch*",
            //(Guards get crushed by crate)
            "Player: Too easy",
            "To_Line207",
            #endregion
            //==-- Intelligence Path 138 --==
            //Pass 144
            #region INT 144
            "Hacking into their devices shouldn’t be a problem.",
            //(pan down to phone)
            "*beep* *boop*",
            //(phone hacking action)
            //(pans back up to look at guards)
            "*BZZZ AAAPPP*... *pop*",
            //(Guards getting mega zapped)
            "*scoff*",
            "now...",
            "To_Line207",
            #endregion
            #region INT 150
            //Fail
            "Hacking into their devices shouldn’t be a problem…",
            "Thoughts: what was that command again… ",
            //(pan down to phone)
            "install windows feature... cd /hacking/Optic-Gaming… yum install swag...",
            "*beep* *boop*",
            //(phone hacking action)
            //(pans back up to look at guards)
            "*bzzz… sss...*",
            "Guards: What was that",
            "It didn't work?... I thought I double checked those commands!",
            "Now I’ll have to shoot them, and FAST",
            "Guards: HEY WHAT ARE YOU D...",
            "*pff* *pff* *pff* *pff* *pff* \n(You kill them with your silenced pistol)",
            "Thoughts: Damn, I think they made too much noise...",
            "Thoughts: Well, I just have to keep going... now...",
            "To_Line207",
            #endregion
            //====-- Charisma Path 163 --====
            #region CHA 163
            //Pass 163
            "Just casually walk up to them…",
            "Guards: What are you doing here? \nWe still have another hour on our shift.",
            "Player: I was told to relieve you. Oh and here, hold on to these.",
            "Guards: huh...",
            "*shunk* *shunk*",
            //(guards get stabbed in the throat)
            "The blades sunk cleanly in. Haha, a fine double kill. 100 points.",
            "With them out of the way that leaves...",
            "To_Line207",
            #endregion
            #region CHA 171
            //Fail 171
            "Just casually walk up to them…",
            "Guards: What are you doing here? \nWe still have another hour on our shift.",
            "Player: The commander told me to relieve you...",

            "Guards: Ha we don’t have a ‘commander’ dumbass.",
            //(Guard Picks up phone)
            "Guard: We have an intrud...",
            "*shunk* *shunk*",
            //(guards get stabbed in the throat)
            "Damn it! Now they know I’m here..",
            "Can’t worry about it now. I have to get in…",
            "To_Line207",
            #endregion
            //=====-- Agility Path 180 --====
            #region AGL 180
            //Pass 180
            "This is gonna look so badass.",
            "Lets do this!",
            //(pictures closer and closer to guards [with speed lines])
            "Guards: huh",

            "Player: *HRAAAGGH*",
            "I slid right in bewteen the guards \nand kicked both of their legs out from under them.",
            //(Picture of this happening)
            "They both fell toward the floor but I caught both of their heads on my two knives.",
            "*THUNK*",
            "*SHUNK* *SHUNK*",
            "Perfect! ",
            "Thoughts: Now that was badass.",
            "Thoughts: No time to think about that though… now on to...",

            "To_Line207",
            #endregion
            #region AGL 192
            //Fail 192
            "This is gonna look pretty cool.",
            "Lets go.",
            //(pictures closer and closer to guards [with speed lines])
            "Guards: huh",
            "Player: hiyaaAAAHHH",
            "*slip*",
            "Player: ...aaahhh",
            "I slipped on a banana peel?! REALLY?...",
            "*Thud*",
            "Didn’t want to have to use my gun but…",
            "Guards: MR. MONT…",
            "*pew* *pew*",
            "Guards: ARGG...",
            "That was to loud.. He might be expecting me… but I can’t back out now.",
            "All thats left is...",
            "To_Line207",
            #endregion
            //=======-- Continue 207 --======
            "The final door…",
            "*creeek*",
            "FaultCheck",
            #region BADEND 210 2 faults
            "...!!!",
            //(monte standing with two guards)
            "VP's son: End of the line assassin",
            "Player: Damn",
            "I made too many mistakes...",
            "VP's son: Get him",
            //(Guards run up to you)
            "I was so close...",
            "*shunk*",
            "You have been killed on your final encounter...",
            "As punishment your game data will now be erased. Goodbye agent.",
            "DEAD",
            #endregion
            #region PASSEND 220 1 fault
            //(Monte is sitting at a desk working)
            "If I can just sneak up behind him...",
            //(monte turn in his chair holding a waifu pillow)
            "...",
            "*BANG*",
            "Player: AAAGH",
            "...m-m-my arm!!",
            "VP's son: It's rude to sneak up on a man with his waifu.",
            "VP's son: I'm Monte Bosstacular. I've been expecting you.",
            "I was... too careless...",
            "Monte: Did you think you could just waltz in while I was asleep and off me?",
            "Gaah… My shooting arm is busted… If i can just get to my knive…",
            "Monte: I had a feeling the grandmaster would send one of his little assassins",
            "Grandmaster?",
            "Monte: He always sends one as a cover for me haha.",
            "Player: Cover?",
            "Monte: HAHAHA you see, him and I...",
            "...no...",
            "Monte: are working together to take over the world!! MUAHAHAHAHA",
            "Player: NOO",
            "Thoughts: got it",
            //(throws knife)
            "*Thunk*",
            "Got him!",
            "Monte: ...*gurgle*... no...my... Wiafus...",
            //(Monte dies)
            "Player: ...haa...haa...haa",
            "Player: I need to... report this...",
            "Player: There are so many questions that need ansewrs",
            "Player: This, is gonna be big...",
            "To_Line269",
            #endregion
            #region PERFECTEND 247 0 faults
            "...no one seems to be here...",
            "Maybe I caught him by surprise",
            //(look around)
            "hmmm… he’s gotta be in the bedroom.",
            "*creek*",
            //(open bedroom door)
            //(monte is there sleeping with his waifu pillow)
            "There you are.",
            "*shake* *shake*",
            "VP's son: ..huh…",
            "Player: Oyasuminasai mother friker \n(Good night)",
            "*SHHUUNK*",
            "It feels good to sink my blade deep into the succulent meat of his neck",
            "VP's son: …*gurgle*... no...my...",
            "VP's son: ...waifus... ",
            "VP's son: and...",
            "and??",

            "VP's son: ...Grand master krebs...I-I-I've failed you...",
            //(monte dies)
            "Failed him... were they...",
            "Working together!!!",
            "What does this mean...",
            "I have to report this as soon as possible.",
            "Player: There are too many questions that need ansewrs",
            "Player: “This, is gonna be big",
            "To_Line269",
            #endregion
            //===================---- Credits 269 ----=====================

            "Credits",
            "Developers \nMartin Hileman & Mitchel Mendez",
            "Developers \nDan Taylor",
            "Developers \nJames Taylor",

            "Guest Actors \nFrank Gu",
            "Guest Actors \nWayne Marie",
            "Guest Actors \nSteven Monte",
            "Guest Actors \nEfren Urena",
            "Guest Actors \nLouis Yeung",
            "Thanks for playing!",
            "END"


        };
        
#endregion
        //===================Methods to change the background===================================-
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
        //1-5
        private void OutsideBuilding(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/1_OutsideBuilding.png");
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
        private void SneekOutside(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/2_sneekOutside.png");
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
        private void lockpick(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/3_lockpick.png");
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
        private void FailCan(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/4_Fail-can.png");
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
        private void ElevatorOrStairs(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/5_ElevatorOrStairs.jpg");
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
        //6-10
        private void stairs(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/6_stairs.png");
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
        private void stairs2(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/7_stairs2.png");
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
        private void stairspanup(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/8_stairspanup.png");
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
        private void stairsHanging(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/10_stairsHanging.png");
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
        //11-15 
        private void stairsfall(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/11_stairsfall.png");
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
        private void stairsGuardAngry(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/12_stairsfall.png");
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
        private void GuardPasses(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/12-5_guardPasses.png");
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
        }//12.5
        private void guardInElevator(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/13_guardInElevator.png");
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
        private void guardInElevatorHappy(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/14_guardInElevatorHappy.png");
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
        private void guardInElevatorMad(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/15_guardInElevatorMad.png");
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
        //16-20 dupe
        private void ElevatorButtons(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/16_ElevatorButtons.jpg");
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
        private void topFloor(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/16_topFloor.png");
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
        private void bin(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/17_bin.png");
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
        private void holdingBin(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/18_holdingBin.png");
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
        private void throwBin(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/19_throw binBin.png");
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
        private void Phone(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/20_INTPhone.png");
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
        //21-25
        private void guardZAP(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/21_INTGuardZap.png");
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
        private void guardNoZAP(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/22_INTNoZap.png");
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
        private void CHAwalkUp(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/23_CHAwalkup.png");
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
        private void CHAGuardYells(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/24_CHAguardYells.png");
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
        private void AGLRunning(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/25_AGLRunning.png");
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
        //26-30
        private void AGLLookingUP(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/26_AGLLookingUP.png");
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
        private void AGLrunFail(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/27_AGLRunFail.png");
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
        private void AGLGetKills(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/28_AGLgGuardsKillYou.png");
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
        private void DeadGuards(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/29_DeadGuards.png");
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
        private void DoorOpens(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/30_DoorOpen.png");
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
        //31-35
        private void MonteAndGuards(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/31_MonteAndGuards.png");
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
        private void MonteAtDesk(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/32_MonteAtDesk.png");
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
        private void MonteTurnAround(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/33_MonteTurnAround.png");
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
        private void MonteHitByKnife(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/34_MonteHitByKnife.png");
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
        private void MonteDeadByKnife(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/35_MonteDeadByKnife.png");
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
        //36-40
        private void EmptyRoom(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/36_EmptyRoom.png");
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
        private void MonteInBed(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/37_MonteInBed.png");
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
        private void MonteWakeUp(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/38_MonteWakeUp.png");
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
        private void MonteDyingInBed(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/39_MonteDyingInBed.png");
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
        private void MonteDeadInBed(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/40_MonteDeadBed.png");
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

        private void Dead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/41_Dead.png");
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

        private void MartinAndMitchel(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/YouAreDead.jpg");
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
        private void Dan(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/YouAreDead.jpg");
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
        private void James(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/DrugLord/FightMe.jpg");
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
        private void Frank(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/13_guardInElevator.png");
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
        private void Wayne(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/12_stairsfall.png");
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
        private void Monte(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/33_MonteTurnAround.png");
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
        private void Efren(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/33_MonteTurnAround.png");
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
        private void Louis(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission3/33_MonteTurnAround.png");
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
        #endregion

        //================================CycleDialogue==================================
        private void CycleDialogue(object sender, MouseButtonEventArgs e)
        {
            #region to Lines
            if (logs[counter].Equals("To_Line57"))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(ElevatorOrStairs);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this); 

                counter = 57;
                testLabel.Content = logs[counter];
                counter++;

            }
            else if (logs[counter].Equals("To_Line134"))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(topFloor);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                counter = 134;
                testLabel.Content = logs[counter];
                counter++;

            }
            else if (logs[counter].Equals("To_Line207"))
            {
                counter = 207;
                testLabel.Content = logs[counter];
                counter++;

            }
            else if (logs[counter].Equals("To_Line269"))
            {
                //CREDITS
                counter = 269;
                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            else if (logs[counter].Equals("END"))
            {
                end();
            }
            else if (logs[counter].Equals("DEAD"))
            {
                death();
            }
            else if (logs[counter].Equals("FaultCheck"))
            {
                faultCheck();
            }

#region TextPictreChange
            #region outside
            else if (logs[counter].Equals(logs[0]))
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
            else if (logs[counter].Equals(logs[22]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(OutsideBuilding);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[25]) || logs[counter].Equals(logs[30]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(SneekOutside);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[32]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(FailCan);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[37]) || logs[counter].Equals(logs[44]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(lockpick);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            //============= Inside: stairs or elevator ==================
            #region Stairs
            else if (logs[counter].Equals(logs[61]) || logs[counter].Equals(logs[75]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairs);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[62]) || logs[counter].Equals(logs[76]) || logs[counter].Equals(logs[71]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairs2);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[66]) || logs[counter].Equals(logs[82]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairspanup);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[68]) || logs[counter].Equals(logs[84]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairsHanging);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[70]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(GuardPasses);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }

            else if (logs[counter].Equals(logs[88]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairsfall);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
                else if (logs[counter].Equals(logs[89]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(stairsGuardAngry);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            #region Elevator
            else if (logs[counter].Equals(logs[100]) || logs[counter].Equals(logs[116]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(guardInElevator);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[108]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(guardInElevatorHappy);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[109]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(ElevatorButtons);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[125]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(guardInElevatorMad);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
                
            #endregion
            //=====================Top floor================
            #region STR bin
            else if (logs[counter].Equals(logs[138]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(bin);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[139]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(holdingBin);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[141]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(throwBin);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            #region INT Phone
            else if (logs[counter].Equals(logs[145]) || logs[counter].Equals(logs[151]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(Phone);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[146]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(guardZAP);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[155]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(guardNoZAP);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            #region CHA WalkUp
            else if (logs[counter].Equals(logs[164]) || logs[counter].Equals(logs[172]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(CHAwalkUp);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
                else if (logs[counter].Equals(logs[175]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(CHAGuardYells);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            #region AGL slide
            else if (logs[counter].Equals(logs[181]) || logs[counter].Equals(logs[193]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(AGLRunning);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[184]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(AGLLookingUP);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[197]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(AGLrunFail);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[203]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(AGLGetKills);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            else if (logs[counter].Equals(logs[208]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(DoorOpens);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #region endings
            else if (logs[counter].Equals(logs[159]) || logs[counter].Equals(logs[177]) || logs[counter].Equals(logs[168]) || logs[counter].Equals(logs[189]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(DeadGuards);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            //BAD
            else if (logs[counter].Equals(logs[211]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteAndGuards);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[216]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(Dead);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            //pass
            else if (logs[counter].Equals(logs[220]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteAtDesk);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[222]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteTurnAround);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[239]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteHitByKnife);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[242]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteDeadByKnife);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            //good
            else if (logs[counter].Equals(logs[247]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(EmptyRoom);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[251]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteInBed);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[253]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteWakeUp);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[256]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteDyingInBed);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[262]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MonteDeadInBed);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion
            #region credits
            else if (logs[counter].Equals(logs[269]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(ImageFadeOut_Completed_HQ);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[270]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(MartinAndMitchel);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[272]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(James);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[273]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(Frank);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[274]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(Wayne);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[275]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(Monte);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            else if (logs[counter].Equals(logs[278]))
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation fade = new DoubleAnimation();
                sb.Completed += new EventHandler(ImageFadeOut_Completed_HQ);
                fade.From = 1.0;
                fade.To = 0.0;
                fade.Duration = new Duration(TimeSpan.FromSeconds(.5));
                sb.Children.Add(fade);
                Storyboard.SetTargetName(fade, TheBackground.Name);
                Storyboard.SetTargetProperty(fade, new PropertyPath(Image.OpacityProperty));

                sb.Begin(this);

                testLabel.Content = logs[counter];
                counter++;
            }
            #endregion


#endregion
            //=============================================
            else if (logs[counter].Equals("Choice"))
            {
                testLabel.Visibility = Visibility.Hidden;
                switch (choiceCounter)
                {
                    case 1:
                        Choice1_SneakOrPick();
                        break;
                    case 2:
                        choice2_StairsOrElevator();
                        break;
                    case 3:
                        choice3_DoubleGuards();
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
        public void Choice1_SneakOrPick()
        {
            testLabe2.Content = "Hmmm...";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Sneak in the side entrance.";
            but1.Visibility = Visibility.Visible;
            
            but2.Content = "Go around to the back and pick the lock.";
            but2.Visibility = Visibility.Visible;
        }

        public void choice2_StairsOrElevator()
        {
            testLabe2.Content = "Am I confident enough to take the elevator? Or should I take the stairs to the top.";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Take the Stairs";
            but1.Visibility = Visibility.Visible;

            but2.Content = "Use the Elevation";
            but2.Visibility = Visibility.Visible;
        }

        public void choice3_DoubleGuards()
        {
            testLabe2.Content = "Gotta be resourceful. hmmm…";
            testLabe2.Visibility = Visibility.Visible;
            if( player.Player_Strength > 7 )
            {
                but1.Content = "Lift a nearby bin and use it to crush the guards";//8 str req
                but1.Visibility = Visibility.Visible;
            }
            
            but2.Content = "Use phone to hack guard’s’ high tech tasers to overload and kill them";//int
            but3.Content = "Classic “Lure guards into a false sense of security” then stab them both";//cha
            but4.Content = "Come in running, slid and catch them with a suprise attack";//agl
            
            but2.Visibility = Visibility.Visible;
            but3.Visibility = Visibility.Visible;
            but4.Visibility = Visibility.Visible;
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
            if (faultCounter == 2)
            {
                counter = 210;
            }
            else if(faultCounter == 1)
            {
                counter = 220;
            }
            else if (faultCounter == 0)
            {
                counter = 247;
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
                        counter = 24;
                    }
                    else
                    {
                        counter = 29;
                        faultCounter++;
                    }
                    userchoice++;
                    break;

                case 1:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        counter = 60;
                    }
                    else
                    {
                        counter = 74;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
                case 2:
                    counter = 138;
                    userchoice++;
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
                    if (player.Player_Intellegence + rand.Next(0, 10) >= 10)
                    {
                        counter = 36;
                    }
                        
                    else
                    {
                        counter = 43;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
                case 1:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        counter = 94;
                    }
                        
                    else
                    {
                        counter = 111;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
                case 2:
                    if (player.Player_Intellegence + rand.Next(0, 10) >= 10)
                    {
                        counter = 144;
                    }

                    else
                    {
                        counter = 150;
                        faultCounter++;
                    }
                    userchoice++;
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
                case 2:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        counter = 163;
                    }

                    else
                    {
                        counter = 171;
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
                case 2:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        counter = 180;
                    }

                    else
                    {
                        counter = 192;
                        faultCounter++;
                    }
                    userchoice++;
                    break;
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
        