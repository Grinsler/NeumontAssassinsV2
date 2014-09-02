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

namespace NeumontAssassinV2.Missions
{
    /// <summary>
    /// Interaction logic for Mission2.xaml
    /// </summary>
    public partial class Mission2 : UserControl
    {
        public List<string> Dialogue, ElevatorChoiceList, RightHallwayList, AltList, SecondFloorHallwayList, ApartmentList, BedroomList;
        public bool failedElevator = false, missionFailure = false, wallFail = false, hallFail = false, StaIntelFail = false;
        public Storyboard start = new Storyboard();
        public DoubleAnimation startfade = new DoubleAnimation();
        public Person player;
        Uri imgsrc;
        BitmapImage bmp;
        public Random rand = new Random();
        int index = 0, choiceIndex = 1, failCounter = 2;

        public Mission2(Person p)
        {
            InitializeComponent();
            startfade.From = 1.0;
            startfade.To = 0.0;
            startfade.Duration = new Duration(TimeSpan.FromSeconds(.5));
            start.Children.Add(startfade);
            Storyboard.SetTargetName(startfade, TheBackground.Name);
            Storyboard.SetTargetProperty(startfade, new PropertyPath(Image.OpacityProperty));
            player = p;
            MakeLists();
        }

        #region DialogueLists
        public void MakeLists()
        {
            #region MainDialogue
            Dialogue = new List<string>()
            {
                /*0*/"Secretary: \"Good to see you again.\"",
                /*1*/"Secretary: \"Another contract for you; this time it’s a man we know to be \nlaundering money from a multibillion dollar organization.\"",
                /*2*/"Secretary: \"Your mission is to take him out as cleanly as possible. Make it look like an \naccident if you can, but if things get messy then that’s okay too.\"",
                /*3*/"Secretary: \"He’s holed up in his apartment on the corner of DeMickey and Virginia, \napartment 235. Get to it, Agent.\"",
                /*4*/"\"DeMickey and Virginia, huh? Shouldn’t be too far away.\"",
                //Transition to picture of City Station in the middle of the day
                /*5*/"OUTSIDE TRAN",
                /*6*/"Thoughts: Made it. Better head inside.",
                //Transition to picture of side door facing the large elevator
                /*7*/"Thoughts: I need to find a way up to Room 235.",
                /*8*/"Choices",
                //First Choice
                //Taking the elevator
                /*9*/"Thoughts: Might as well take the elevator. A couple guards shouldn’t be a problem. \nCertainly not if I can just blend in.",
                /*10*/"You arrive at the 2nd floor, and as the doors open...",
                //Transition to picture of a guard facing the elevator door
                /*11*/"Guard: \"This area is locked down; you're not supposed to be here.\"",
                /*12*/"Choices",
                //Use ElevatorChoiceList
                //Taking the Right Hallway
                /*13*/"Thoughts: Let's see... Ah ha!",
                /*14*/"After a while of walking, you come to an unguarded stairway, leading up to the \nsecond floor. You make your way to the top of the stairs, the door leading out into the \nsecond floor.",
                /*15*/"Thoughts: Hmm...",
                /*16*/"STAIRS",
                /*17*/"Thoughts: Hmm...",
                /*18*/"Choices",
                //Use RightHallwayList
                //Going the alternative route
                /*19*/"You walk around to the back of the building, coutning apartment windows as rooms, \nfiguring out a pattern between them.",
                /*20*/"Thoughts: Each room has two windows, so every third window must be a new room.",
                /*21*/"BACK ENTRANCE",
                /*22*/"Thoughts: So this is Room 235.",
                /*23*/"You stare up at the two windows, the blinds are closed and both windows are shut, \npossibly locked.",
                /*24*/"Thoughts: There must be a way inside.",
                /*25*/"Choices",
                //Use AltList            
            #endregion
            #region ElevatorChoiceList
                //STRENGTH SUCCESS
                /*26*/"The guard topples back and slumps against the back wall; he's knocked out... For now",
                /*27*/"DEAD ELE GUARD",
                /*28*/"Thoughts: Well, that was easy. Looks like he's more bark than bite.",
                /*29*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //STRENGTH FAIL
                /*30*/"\"Ooof!\"",
                /*31*/"The guard expects your punch and retaliates, punching you in the stomach and causing you to double over.",
                /*32*/"He then shoves you back inside the elevator and slams the emergency doors shut, locking you from getting in.",
                /*33*/"Thoughts: Shoot, that didn't work. They'll probably be expecting me now.",
                /*34*/"FaultCount",
                //+1 Failure Counter, failedElevator = true, Return back to First Choice with Taking the elevator greyed out.
                //AGILITY SUCCESS
                /*35*/"The guard is toppled backwards as you run past him. As this happens, he stumbles \nback far enough and hits his head against the back wall, rendering him unconcious.",
                /*36*/"DEAD ELE GUARD",
                /*37*/"Thoughts: Easy. Now that he's down, just gotta get to the apartment",
                /*38*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //AGILITY FAILURE
                /*39*/"You attempt to slip past the guard, but he grabs hold of your arm!",
                /*40*/"Guard: \"Don't even try it.\"",
                /*41*/"The guard pushes you back towards the elevator, a sword defensively drawn, aimed at you.",
                /*42*/"\"Fine... I'll go.\"",
                /*43*/"You return back to the first floor down the elevator.",
                /*44*/"FaultCount",
                //+1 Failure Counter, failedElevator = true, Return back to First Choice with Taking the elevator greyed out.
                //BASE CHOICE 1 SUCCESS
                /*45*/"\"Just answer me this: When does the narwhal bacon?\"",
                /*46*/"Guard: \"Wha- what are you smoking? Get out of here!\"",
                /*47*/"\"Answer the question.\"",
                /*48*/"Guard: \"Hmm...\"",
                /*49*/"The guard seems both distracted and perplexed by the question, turning his back in \nnegligent thought. At that, you slip away.",
                /*50*/"RUN PAST GUARD",
                /*51*/"Thoughts: The good ol' Reddit Mindtrick. Never fails.",
                /*52*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //BASE CHOICE 1 FAILURE
                /*53*/"\"Just answer me this: When does the narwhal bacon?\"",
                /*54*/"Guard: \"Wha- what are you smoking? Get out of here!\"",
                /*55*/"Thoughts: Seems like he's not messing around. Better head back down, I guess.",
                /*56*/"FaultCount",
                //+1 Failure Counter, failedElevator = true, Return back to First Choice with Taking the elevator greyed out.
                //BASE CHOICE 2
                /*57*/"You return back down the elevator, submissive in your attempt.",
                /*58*/"BAILED OUT",
                //Return back to First Choice with Taking the elevator greyed out.
#endregion
            #region RightHallwayList
                //BASE CHOICE 1 SUCCESS
                /*59*/"Thoughts: Line up the shot... Bam!",
                /*60*/"With a pull of the trigger, the guard's body slumps over as the gun's bullet pierces the \nwindow mostly silently, and hits the guard right in the back of the head." +  
                " You open the \ndoor and step inside.",
                /*61*/"STAIR GUARD DEAD",
                /*62*/"Thoughts: The target should be in this next hallway.",
                /*63*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //BASE CHOICE 1 FAILURE
                /*64*/"Thoughts: Line up the shot... Bam!",
                /*65*/"Despite much confidence, the bullet lodges inside of what must have been bulletproof glass. The guard turns to face you, alarmed by the sound.",
                /*66*/"Guard: \"What the fu-!\"",
                /*67*/"STAIRSDEAD",
                /*68*/"The guard spins around and hits you in the face with the hilt of his katana, causing you to fall to the ground.",
                /*69*/"You manage to jump back up and push past him, then run further into the apartment complex. He gives up quickly.",
                /*70*/"BEGIN THE HALL",
                //STRENGTH SUCCESS
                /*71*/"Thoughts: Time for the classic death-by-door scene.",
                /*72*/"You slam open the door, the guard now sporting a large gash in his skull, lying dead on \nthe ground.",
                /*73*/"STAIR GUARD DEAD",
                /*74*/"Thoughts: That was louder than expected, but totally worth it. Hope no one heard it.",
                /*75*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //STRENGTH FAILURE
                /*76*/"The guard just happens to meander forward just far enough to dodge the door as you open it. This results in the door slamming against the wall."+ 
                " He turns around and quickly pushes you into the stairs.",
                /*77*/"The land causes the back of your head to smack against the stairs. You clumsily get back up and push past him. He gives up quickly.",
                /*78*/"BEGIN THE HALL",
                //INTELLIGENCE SUCCESS
                /*79*/"Thoughts: Should be able to redirect him down to the other hallway.",
                /*80*/"You hack into the guard's two-way radio and speak in a hushed, but stern tone.",
                /*81*/"\"Rotate positions.\"",
                /*82*/"The guard lets out an audible sigh and walks down the left hallway. As he leaves, you \nstep into the hallway silently.",
                /*83*/"BEGIN THE HALL",
                //Use SecondFloorHallwayList
                //INTELLIGENCE FAILURE
                /*84*/"Thoughts: Should be able to redirect him down the other hallway.",
                /*85*/"Thoughts: Come on, come on...",
                /*86*/"Thoughts: Dang it! Why isn't this working?",
                /*87*/"Thoughts: Well.. What else can I do, then?",
                //Reset RightHallwayList, with the Intelligence option greyed out/not visible.
       
#endregion
            #region AltList
                //AGILITY SUCCESS
                /*88*/"You run up the side of the building, grabbing hold of the window ledge, \nlooking up slightly to see if the window is locked.",
                /*89*/"Thoughts: Oh good, it's not!",
                /*90*/"INSIDE APT",
                /*91*/"You climb inside what looks to be the target's bedroom -- what a mess. \nThe door is slightly open, but no one's seen you.",
                /*92*/"UNSUSPECTING LIFE",
                //Use BedroomList
                //AGILITY FAILURE
                /*93*/"As you scramble up the side of the building, the ledge breaks from your weight and you fall down to the asphalt, ",
                /*94*/"now with a twisted ankle and scraped knee.",
                /*95*/"FaultCount",
                //+1 Failure Counter, return to Main Room
                //Base Choice
                /*96*/"Thoughts: Hm.. Doesn't seem like I can climb that without drawing a bunch of attention.",
                /*97*/"BAILED OUT",
                //Return to main room
#endregion
            #region SecondFloorHallwayList
                /*98*/"Thoughts: Looks like those guards at the end of the hallway are blocking the way \ninto the apartment.",
                /*99*/"I'll have to find some way to distract them. Or maybe...",
                /*100*/"Choices",
                //BASE CHOICE 1 SUCCESS
                /*101*/"Thoughts: I'll just turn out the lights!",
                /*102*/"The guards become alerted by the lack of light, and in their attempt to turn the lights \nback on, they bump into each other, thinking the other is the culprit, and strangle each \nother to death.",
                /*103*/"SUICIDE GUARDS",
                /*104*/"Thoughts: That just happened.",
                /*105*/"INSIDE MAIN APT",
                //Use ApartmentList
                //BASE CHOICE 1 FAILURE
                /*106*/"Thoughts: I'll just turn out the lights!",
                /*107*/"The guards spot you as you approach the lightswitch. They tackle you and restrain you \nto the ground.",
                /*108*/"MIS FAIL",
                /*109*/"Moments later, a helicopter is heard leaving the complex. Critical Mission Failure.",
                //MissionFailure = true
                //AGILITY SUCCESS
                /*110*/"Perfectly synchronized shots lead two bullets into the skulls of the two guards, who \nsimply collapse to the ground, dead.",
                /*111*/"DEAD HALL GUARDS",
                /*112*/"Thoughts: Done like dinner.",
                /*113*/"INSIDE MAIN APT",
                //Use ApartmentList
                //AGILITY FAILURE
                /*114*/"The guards spot you as you pull out your silenced pistol! They rush towards you and \ntackle you to the ground.",
                /*115*/"MIS FAIL",
                /*116*/"Their swords are drawn, staring down at you. You're at their mercy now.",
                /*117*/"DEAD",
                //Revert back to last save.
                //CHARISMA SUCCESS
                /*118*/"Guard: \"Hey! Identify yourself!\"",
                /*119*/"\"Yeeeaaah... I'm a client, see. So I'm gonna need you to let me in... If you could do that, \nthat'd be great.\"",
                /*120*/"The guard looks to his partner, who nods.",
                /*121*/"CHARS SUCCESS",
                /*122*/"Guard: \"Alright. Go on in.\"",
                /*123*/"INSIDE MAIN APT",
                //Use ApartmentList
                //CHARISMA FAILURE
                /*124*/"\"I'm here to see the boss. Let me in, or else.\"",
                /*125*/"The guard laughs mockingly.",
                /*126*/"Guard: \"Or else what? You're not getting in unless you're on the list!\"",
                /*127*/"CHARS FAIL",
                /*128*/"You return back to the hallway, the guards being very wary of you now.",
                /*129*/"Thoughts: Time to come up with a new way in.",
                /*130*/"FaultCount",
                //+1 to Failure Counter, return to the beginning of this list, with the Charisma option not available
#endregion
            #region ApartmentList
                //0 Failure Counter
                /*131*/"Thoughts: Doesn't look like anyone's here. I should hide in the bedroom!",
                /*132*/"INSIDE APT",
                //Use BedroomList
                //1 Failure Counter
                /*133*/"Guard: \"Go on in. The boss is expecting you.\"",
                /*134*/"\"Alright.\"",
                /*135*/"GO TO BAD BED",
               /*136*/"???: \"Good evening. You must be the assassin.\"",
                /*137*/"Thoughts: What?! How did he figure me out?!",
                /*138*/"\"Yes.\"",
                /*139*/"???: \"Well. Do it then.\"",
                /*140*/"The man hands you a pistol, ordering you to shoot him.",
                /*141*/"???: \"Go ahead. I've got it coming.\"",
                /*142*/"You pull the trigger. The man slumps over, dead. Guards rush in, throwing you out of \nthe bedroom window!",
                /*143*/"Thankfully, you made it out okay, albeit scuffed up with several bruised muscles and a \ncouple cuts.",
                /*144*/"Thoughts: That could've gone better.",
                /*145*/"END",
                //missionFailure = false
                //2 Failure Counter
                /*146*/"Guard: \"There's the assassin! Kill 'em!\"",
                /*147*/"The guards rush you; what seems like an innumerable amount of attacks from every \nangle and corner.",
                /*148*/"It seems impossible to fend them off, and eventually. . .",
                /*149*/"DEAD",
                //Fade to black
                /*150*/"You have died. You handed them the bat, and they swung",
#endregion
            #region BedroomList
                /*151*/"Thoughts: Ugh, what a mess!",
                /*152*/"UNSUSPECTING LIFE",
                /*153*/"The bedroom looks empty, so you climb inside of the closet and wait for the man to \neventually come inside.",
                /*154*/"As the sun sets, the man walks inside and settles down in the lush executive chair, \nstaring towards his computer monitor. He hasn't seen you.",
                /*155*/"???: \"You did good today, Dan. Another three-hundo-thou in the bag.\"",
                /*156*/"Choices",
                //AGILITY
                /*157*/"You pull out your fiber wire, stepping out of the closet.",
                /*158*/"UNSUSPECTING DEATH",
                /*159*/"Tightening the wire around his neck, you pull him towards you until he stops moving. \nMission well done.",
                /*160*/"END",
                //INTELLIGENCE
                /*161*/"You adjust your hacking device until it picks up the chair's frequencies, and launch him \nup into the ceiling.",
                /*162*/"UNSUSPECTING DEATH",
                /*163*/"He falls back down, hitting his chair and snapping his neck against the headrest.",
                /*164*/"END",
                //STRENGTH
                /*165*/"You push the man into the window. While he doesn't go through the window, the force \nsnaps his neck.",
                /*166*/"WINDOWS",
                /*167*/"He remains facing the window, face down.",
                /*168*/"END",
                //CHARISMA
                /*169*/"\"HADOUKEN!\"",
                /*170*/"FACEDEAD",
                /*171*/"You hold your hand out flat, clenching it into a fist swiftly and punching a clean hole \nin his chest.",
                /*172*/"I mean, crap, man. That's like... Not even supposed to be possible. It's just one solid \nchunk!",
                //END OF MISSION
                /*173*/"END"
#endregion
            };
        }
        #endregion
        #region Image Transitions
        public void ImageFadeOut_Completed_Secretary(object sender, EventArgs e)
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
        public void ImageFadeOut_Completed_EndMission(object sender, EventArgs e)
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
        public void ImageFadeOut_Completed_OutsideBuilding(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Front of Building.jpg");
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
        public void ImageFadeOut_Completed_InsideBuilding(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Inside the Building.jpg");
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
        public void ImageFadeOut_Completed_AlternateRoute(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Back of Apartment.jpg");
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
        public void ImageFadeOut_Completed_ElevatorGuardLive(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Elevator GuardLive.jpg");
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
        public void ImageFadeOut_Completed_ElevatorGuardDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Elevator GuardDead.jpg");
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
        public void ImageFadeOut_Completed_RunPastElevatorGuard(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/RunPast Elevator.jpg");
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
        public void ImageFadeOut_Completed_ElevatorDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Elevator Dead.jpg");
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
        public void ImageFadeOut_Completed_StairsGuardLive(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Stair GuardLive.jpg");
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
        public void ImageFadeOut_Completed_StairsGuardDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Stair GuardDead.jpg");
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
        public void ImageFadeOut_Completed_StairsDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Stairs Dead.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallway(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/SecondFloorHallway.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallwayDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/SecondFloorHallway Dead.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallwayLive(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Hallway GuardSuicide.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallwayDeadGuards(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/SecondFLoorHallway_DeadGuards.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallwayCharSuc(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/SecondFloorHallway_CharismaSucc.jpg");
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
        public void ImageFadeOut_Completed_SecondFloorHallwayCharFail(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/SecondFloorHallway_CharismaFail.jpg");
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
        public void ImageFadeOut_Completed_MainAptEmpty(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Main Apt Empty.jpg");
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
        public void ImageFadeOut_Completed_PlusFailCountMain(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Plus1FailCount Main.jpg");
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
        public void ImageFadeOut_Completed_PlusTwoFailCountMain(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Plus2FailCount Main.jpg");
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
        public void ImageFadeOut_Completed_PlusFailCountBedLive(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Plus1FailCount BedLive.jpg");
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
        public void ImageFadeOut_Completed_PlusFailCountBedDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Plus1FailCount BedDead.jpg");
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
        public void ImageFadeOut_Completed_Unsuspecting(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Unsuspecting.jpg");
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
        public void ImageFadeOut_Completed_EmptyApt(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/Inside Empty Apt.jpg");
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
        public void ImageFadeOut_Completed_UnsuspectingDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/UnsuspectingDead.jpg");
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
        public void ImageFadeOut_Completed_WindowDead(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/Mission 2/WindowDead.jpg");
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
        #region CycleDialogue
        public void CycleDialogue(object sender, MouseButtonEventArgs e)
        {
            #region Non-Choice-Dialogue
            if (Dialogue[index].Equals("OUTSIDE TRAN"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_OutsideBuilding);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("END"))
            {
                End();
            }
            else if (Dialogue[index].Equals("FaultCount"))
            {
                FaultCount();
            }
            else if (Dialogue[index].Equals("DEAD"))
            {
                Dead();
            }
            else if (index == 0)
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_Secretary);
                start.Begin(this);
                testLabel.Content = Dialogue[index];
                index++;
            }
            else if (index == 11)
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_ElevatorGuardLive);
                start.Begin(this);
                testLabel.Content = Dialogue[index];
                index++;
            }
            else if (index == 109)
            {
                failCounter = 2;
                End();
            }
            else if (Dialogue[index].Equals("BACK ENTRANCE"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_AlternateRoute);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("DEAD ELE GUARD"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_ElevatorGuardDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("RUN PAST GUARD"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_RunPastElevatorGuard);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("STAIRS"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_StairsGuardLive);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("STAIR GUARD DEAD"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_StairsGuardDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("STAIRSDEAD"))
            {
                missionFailure = true;
                start.Completed += new EventHandler(ImageFadeOut_Completed_StairsDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("INSIDE APT"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_EmptyApt);
                start.Begin(this);
                index = 151;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("BAILED OUT"))
            {
                index = 7;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("SUICIDE GUARDS"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallwayLive);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("MIS FAIL"))
            {
                missionFailure = true;
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallwayDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("BEGIN THE HALL"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallway);
                start.Begin(this);
                index = 98;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("CHARS SUCCESS"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallwayCharSuc);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("CHARS FAIL"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallwayCharFail);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("DEAD HALL GUARDS"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_SecondFloorHallwayDeadGuards);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("INSIDE MAIN APT"))
            {
                switch (failCounter)
                {
                    case 0:
                        start.Completed += new EventHandler(ImageFadeOut_Completed_MainAptEmpty);
                        index = 131;
                        testLabel.Content = Dialogue[index];
                        break;
                    case 1:
                        start.Completed += new EventHandler(ImageFadeOut_Completed_PlusFailCountMain);
                        index = 133;
                        testLabel.Content = Dialogue[index];
                        break;
                    case 2:
                        start.Completed += new EventHandler(ImageFadeOut_Completed_PlusTwoFailCountMain);
                        index = 146;
                        testLabel.Content = Dialogue[index];
                        break;
                }
                start.Begin(this);
            }
            else if (Dialogue[index].Equals("GO TO BAD BED"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_PlusFailCountBedLive);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("FACEDEAD"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_PlusFailCountBedDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("END"))
            {
                //IMPLEMENT MARTIN'S END MISSION LOGIC HERE
            }
            else if (Dialogue[index].Equals("UNSUSPECTING LIFE"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_Unsuspecting);
                start.Begin(this);
                choiceIndex = 6;
                index = 153;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("UNSUSPECTING DEATH"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_UnsuspectingDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            else if (Dialogue[index].Equals("WINDOWS"))
            {
                start.Completed += new EventHandler(ImageFadeOut_Completed_WindowDead);
                start.Begin(this);
                index++;
                testLabel.Content = Dialogue[index];
            }
            #endregion
            else if (Dialogue[index].Equals("Choices"))
            {
                testLabel.Visibility = Visibility.Hidden;
                switch (choiceIndex)
                {
                    case 1:
                        start.Completed += new EventHandler(ImageFadeOut_Completed_InsideBuilding);
                        start.Begin(this);
                        choice1_InBuilding();
                        break;
                    case 2:
                        choice2_AtElevator();
                        break;
                    case 3:
                        choice3_StairsGuard();
                        break;
                    case 4:
                        choice4_BackEntrance();
                        break;
                    case 5:
                        choice5_SecondFloorHallway();
                        break;
                    case 6:
                        choice6_Unsuspecting();
                        break;
                }
            }
            else
            {
                testLabel.Content = Dialogue[index];
                index++;
            }
        }
        #endregion
        #region Choices
        public void choice1_InBuilding()
        {
            testLabe2.Content = "Thoughts: 235... Second floor. Maybe he has a balcony? Elevator could work. Or stairs.";
            testLabe2.Visibility = Visibility.Visible;
            but1.Content = "Take the elevator";
            if (failedElevator)
            {
                but1.Visibility = Visibility.Hidden;
            }
            else
            {
                but1.Visibility = Visibility.Visible;
            }
            but2.Content = "Take the stairs";
            but2.Visibility = Visibility.Visible;
            but3.Content = "Try an alternate route";
            but3.Visibility = Visibility.Visible;
        }
        public void choice2_AtElevator()
        {
            testLabe2.Content = "Thoughts: A guard! How can I get past him?";
            testLabe2.Visibility = Visibility.Visible;
            if (player.Player_Strength >= 7)
            {
                but1.Content = "Punch the guard";
                but1.Visibility = Visibility.Visible;
            }
            if (player.Player_Agility >= 7)
            {
                but2.Content = "Push past the guard";
                but2.Visibility = Visibility.Visible;
            }
            but3.Content = "Ask the guard a question";
            but3.Visibility = Visibility.Visible;
            but4.Content = "Go back down the elevator";
            but4.Visibility = Visibility.Visible;
        }
        public void choice3_StairsGuard()
        {
            testLabe2.Content = "Thoughts: Looks like a guard. I'll have to take him out without seeing me.";
            testLabe2.Visibility = Visibility.Visible;

            but1.Content = "Shoot the guard in the head";
            but1.Visibility = Visibility.Visible;
            if (player.Player_Strength >= 7)
            {
                but2.Content = "Open the door hard enough to crack the guard's skull open";
                but2.Visibility = Visibility.Visible;
            }
            if (player.Player_Intellegence >= 7 && !StaIntelFail)
            {
                but3.Content = "Utilize your hacking device to redirect his position";
                but3.Visibility = Visibility.Visible;
            }
        }
        public void choice4_BackEntrance()
        {
            testLabe2.Content = "Thoughts: Could try to run up that wall into his apartment.";
            testLabe2.Visibility = Visibility.Visible;
            if (player.Player_Agility >= 9)
            {
                but1.Content = "Wallrun up the wall and grasp the ledge of the window";
                but1.Visibility = Visibility.Visible;
            }
            but2.Content = "Go back to the main room";
            but2.Visibility = Visibility.Visible;
        }
        public void choice5_SecondFloorHallway()
        {
            testLabe2.Content = "Thoughts: I'll have to find some way to distract them. Or maybe...";
            testLabe2.Visibility = Visibility.Visible;
            but1.Content = "Turn out the lights";
            but1.Visibility = Visibility.Visible;
            if (player.Player_Agility >= 7)
            {
                but2.Content = "Shoot both of them with a silenced pistol";
                but2.Visibility = Visibility.Visible;
            }
            if (player.Player_Charisma >= 7)
            {
                but3.Content = "Convince them to let you in";
                but3.Visibility = Visibility.Visible;
            }
        }
        public void choice6_Unsuspecting()
        {
            testLabe2.Content = "Thoughts: There he is! How to take him out. . .";
            testLabe2.Visibility = Visibility.Visible;
            if (player.Player_Charisma >= 7)
            {
                but1.Content = "Spin the man around and Five Finger Death Punch him";
                but1.Visibility = Visibility.Visible;
            }
            if (player.Player_Strength >= 7)
            {
                but2.Content = "Push the man and his chair into the window";
                but2.Visibility = Visibility.Visible;
            }
            if (player.Player_Intellegence >= 7)
            {
                but3.Content = "Hack the electronic controls on his chair";
                but3.Visibility = Visibility.Visible;
            }
            if (player.Player_Agility >= 7)
            {
                but4.Content = "Strangle the man with fiber wire";
                but4.Visibility = Visibility.Visible;
            }
        }
        #endregion
        #region Ending
        public void End()
        {
            start.Completed += new EventHandler(ImageFadeOut_Completed_Secretary);
            start.Begin(this);
            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            switch (failCounter)
            {
                case 0:
                    testLabel.Content = "You did very well, " + player.Player_Name + ", keep it up.";
                    testLabel.Visibility = Visibility.Visible;
                    break;
                case 1:
                    testLabel.Content = "You did okay, " + player.Player_Name + ", be more careful next time, though.";
                    testLabel.Visibility = Visibility.Visible;
                    break;
                case 2:
                    testLabel.Content = "I can't believe you let the target get away, " + player.Player_Name + ". You disappoint me.";
                    testLabel.Visibility = Visibility.Visible;
                    break;
            }
        }
        #endregion
        #region Fails
        public void FaultCount()
        {
            if (index == 30 || index == 39 || index == 53)
            {
                failedElevator = true;
            }
            else if (index == 88)
            {
                wallFail = true;
                failCounter++;
            }
            else if (index == 121)
            {
                hallFail = true;
                failCounter++;
            }
        }
        #endregion
        #region Dead
        public void Dead()
        {
            failCounter = 0;
            index = 0;
            choiceIndex = 1;
        }
        #endregion
        #region Buttons
        public void but1_choice(object sender, RoutedEventArgs e)
        {
            switch (choiceIndex)
            {
                case 1:
                    index = 9;
                    choiceIndex = 2;
                    break;
                case 2:
                    if (player.Player_Strength + rand.Next(0, 10) >= 10)
                    {
                        index = 26;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 30;
                        choiceIndex = 1;
                        failedElevator = true;
                    }
                    break;
                case 3:
                    if ((player.Player_Charisma + player.Player_Intellegence + player.Player_Strength + player.Player_Agility) / 4 + rand.Next(10) >= 10)
                    {
                        index = 59;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 64;
                        choiceIndex = 5;
                        failCounter++;
                    }
                    break;
                case 4:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        index = 88;
                        choiceIndex = 6;
                    }
                    else
                    {
                        index = 93;
                    }
                    break;
                case 5:
                    if ((player.Player_Charisma + player.Player_Intellegence + player.Player_Strength + player.Player_Agility) / 4 + rand.Next(10) >= 10)
                    {
                        index = 101;
                        choiceIndex++;
                    }
                    else
                    {
                        index = 106;
                        failCounter = 100;
                        missionFailure = true;
                    }
                    break;
                case 6:
                    index = 169;
                    break;

            }
            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = Dialogue[index];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }
        public void but2_choice(object sender, RoutedEventArgs e)
        {
            switch (choiceIndex)
            {
                case 1:
                    index = 13;
                    choiceIndex = 3;
                    break;
                case 2:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        index = 35;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 39;
                        failedElevator = true;
                        choiceIndex = 1;
                    }
                    break;
                case 3:
                    if (player.Player_Strength + rand.Next(0, 10) >= 10)
                    {
                        index = 71;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 76;
                        choiceIndex = 5;
                        failCounter++;
                    }
                    break;
                case 4:
                    index = 96;
                    choiceIndex = 1;
                    break;
                case 5:
                    if (player.Player_Agility + rand.Next(0, 10) >= 10)
                    {
                        index = 110;
                        choiceIndex++;
                    }
                    else
                    {
                        index = 114;
                        missionFailure = true;
                    }
                    break;
                case 6:
                    index = 165;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = Dialogue[index];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }
        public void but3_choice(object sender, RoutedEventArgs e)
        {
            switch (choiceIndex)
            {
                case 1:
                    index = 19;
                    choiceIndex = 4;
                    break;
                case 2:
                    if ((player.Player_Charisma + player.Player_Intellegence + player.Player_Strength + player.Player_Agility) / 4 + rand.Next(10) >= 10)
                    {
                        index = 45;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 53;
                        choiceIndex = 1;
                        failedElevator = true;
                    }
                    break;
                case 3:
                    if (player.Player_Intellegence + rand.Next(0, 10) >= 10)
                    {
                        index = 79;
                        choiceIndex = 5;
                    }
                    else
                    {
                        index = 84;
                        StaIntelFail = true;
                    }
                    break;
                case 5:
                    if (player.Player_Charisma + rand.Next(0, 10) >= 10)
                    {
                        index = 118;
                        choiceIndex++;
                    }
                    else
                    {
                        index = 124;
                        hallFail = true;
                    }
                    break;
                case 6:
                    index = 161;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = Dialogue[index];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }
        public void but4_choice(object sender, RoutedEventArgs e)
        {
            switch (choiceIndex)
            {
                case 2:
                    index = 57;
                    choiceIndex = 1;
                    failedElevator = true;
                    break;
                case 6:
                    index = 157;
                    break;
            }

            testLabel.Visibility = Visibility.Visible;
            testLabel.Content = Dialogue[index];

            testLabe2.Visibility = Visibility.Hidden;
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Hidden;
            but4.Visibility = Visibility.Hidden;
        }
        #endregion
        #region Styling
        public void Button_Choice3_MouseEnter_1(object sender, MouseEventArgs e)
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
        public void Button_Choice2_MouseEnter_1(object sender, MouseEventArgs e)
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
        public void Button_Choice1_MouseEnter_1(object sender, MouseEventArgs e)
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
        public void Button_Choice4_MouseEnter_1(object sender, MouseEventArgs e)
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
        #endregion

    }
}
