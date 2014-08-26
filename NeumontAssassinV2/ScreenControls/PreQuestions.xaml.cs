using NeumontAssassinV2.Missions;
using NeumontAssassinV2.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeumontAssassinV2.ScreenControls
{
    /// <summary>
    /// Interaction logic for PreQuestions.xaml
    /// </summary>
    public partial class PreQuestions : UserControl
    {
        public PreQuestions()
        {
            InitializeComponent();
        }

        public int count = 1;
        public int testing { get; set; }
        public int UserChoice { get; set; }
        Uri imgsrc;
        BitmapImage bmp;

        //=========================Image Transition Demo=================================
        private void ImageFadeOut_Completed(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/secretary.jpg");
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

        //===============================================================================

        //====================================Buttons====================================
        

        private void Questions()
        {
            //create a method to change the label to introduce and explain the prequestions
            if (count == 1)
            {
                this.Label_Choices.Content = "You are confronted by a guard for trespassing, your face isn’t familiar. What do you do?";
            }
            if (count == 2)
            {
                this.Label_Choices.Content = "You are tailing your target at dusk, he turns to look behind him. What would you do next.";
            }
            if (count == 3)
            {
                this.Label_Choices.Content = "You’ve just finished up a long day of work. You want to unwind. What is your first decision?";
            }
            if (count == 4)
            {
                this.Label_Choices.Content = "What is your preferred weapon of choice?";
            }
            count++;
            Choices();
            
        }

        private void Choices()
        {
            if (count == 1)
            {
                this.Button_Choice1.Content = "Run past him while lifting the credentials and communication device from his belt.";
                this.Button_Choice2.Content = "Run. Run far away.";
                this.Button_Choice3.Content = "Tell the guard you are a consultant and have been granted access by the boss.";
                this.Button_Choice4.Content = "Takedown the guard with brute force.";
            }
            else if (count == 2)
            {
                this.Button_Choice1.Content = "Quickly roll into a nearby alley and break line of sight.";
                this.Button_Choice2.Content = "Use your hacking device to turn off the street lights.";
                this.Button_Choice3.Content = "Act like just another average person on the street.";
                this.Button_Choice4.Content = "Run up to him and dispatch him right there.";
            }
            else if (count == 3)
            {
                this.Button_Choice1.Content = "Jog around the block";
                this.Button_Choice2.Content = "Read comic books";
                this.Button_Choice3.Content = "Go for a drink at the bar.";
                this.Button_Choice4.Content = "Lift weights.";
            }
            //else if (Label_Choices.Content.Equals("What is your preferred weapon of choice?"))
            //{
            //    this.Button_Choice1.Content = "Piano wire";
            //    this.Button_Choice2.Content = "My computer";
            //    this.Button_Choice3.Content = "All I need is my looks.";
            //    this.Button_Choice4.Content = "My fists";
            //}
        }
        private void Choice2()
        {
            this.Button_Choice1.Content = "Piano wire";
            this.Button_Choice2.Content = "My computer";
            this.Button_Choice3.Content = "All I need is my looks.";
            this.Button_Choice4.Content = "My fists";

            MainWindow mw = new MainWindow();
            mw.Content = new DrugLord(new Person());
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mw;
            mw.Show();                      
        }
        private void ButtonChoice1(object sender, RoutedEventArgs e)
        {
            UserChoice = 1;
            Questions();
        }
        private void ButtonChoice2(object sender, RoutedEventArgs e)
        {
            UserChoice = 2;
            Questions();
        }

        private void ButtonChoice3(object sender, RoutedEventArgs e)
        {
            UserChoice = 3;
            Questions();
        }

        private void ButtonChoice4(object sender, RoutedEventArgs e)
        {
            UserChoice = 4;

            if (count < 4)
            {
                Questions();
            }
            else
            {
                Choice2();
            }
            

        }

        public void MissionDialog(string setup, string but1, string but2, string but3)
        {
            Label_SetUp.Content = setup;
            Button_Choice1.Content = but1;
            Button_Choice2.Content = but2;
            Button_Choice3.Content = but3;

        }

        public void MissionDialog(string setup, string but1, string but2)
        {
            Label_SetUp.Content = setup;
            Button_Choice1.Content = but1;
            Button_Choice2.Content = but2;
            Button_Choice3.Visibility = Visibility.Hidden;

        }

        public void MissionDialog(string setup)
        {
            Label_SetUp.Content = setup;
            Button_Choice1.Visibility = Visibility.Hidden;
            Button_Choice2.Content = "Next";
            Button_Choice3.Visibility = Visibility.Hidden;
        }

        //=================================Button Style===================================
        private void Button_Choice4_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.Button_Choice4.Foreground.Equals(Brushes.Black))
            {
                this.Button_Choice4.Foreground = (Brushes.White);
            }
            else
            {
                this.Button_Choice4.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice3_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.Button_Choice3.Foreground.Equals(Brushes.Black))
            {
                this.Button_Choice3.Foreground = (Brushes.White);
            }
            else
            {
                this.Button_Choice3.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.Button_Choice2.Foreground.Equals(Brushes.Black))
            {
                this.Button_Choice2.Foreground = (Brushes.White);
            }
            else
            {
                this.Button_Choice2.Foreground = (Brushes.Black);
            }
        }
        private void Button_Choice1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (this.Button_Choice1.Foreground.Equals(Brushes.Black))
            {
                this.Button_Choice1.Foreground = (Brushes.White);
            }
            else
            {
                this.Button_Choice1.Foreground = (Brushes.Black);
            }
        }
    }
}
