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

namespace NeumontAssassinV2.ScreenControls
{
    /// <summary>
    /// Interaction logic for MissionControl.xaml
    /// </summary>
    public partial class MissionControlTemplate : UserControl
    {
        public int testing { get; set; }
        public int UserChoice { get; set; }
        Uri imgsrc;
        BitmapImage bmp;

        public MissionControlTemplate()
        {
            InitializeComponent();
            Button_Choice1.Content = "Do it!";
        }
        //=========================Image Transition Demo=================================
        private void ImageFadeOut_Completed(object sender, EventArgs e)
        {
            imgsrc = new Uri("pack://application:,,,/Images/secretary.jpg");
            bmp = new BitmapImage(imgsrc);
            TheBackground.Source = bmp;
            Storyboard SFadeIn = new Storyboard();
            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;                                                       //THIS METHOD WILL REQUIRE CHANGING OF THE IMAGE PATH ACCORDINGLY, BUT THAT'S IT.
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeIn.Children.Add(FadeIn);
            Storyboard.SetTargetName(FadeIn, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeIn, new PropertyPath(Image.OpacityProperty));
            SFadeIn.Begin(this);
        }
        //===============================================================================

        //====================================Buttons====================================
        private void ButtonChoice1(object sender, RoutedEventArgs e)
        {
            UserChoice = 1;
            Storyboard SFadeOut = new Storyboard();
            SFadeOut.Completed += new EventHandler(ImageFadeOut_Completed);

            DoubleAnimation FadeOut = new DoubleAnimation();                        //THIS METHOD CAN BE IMPLEMENTED ANYWHERE NECESSARY -- IT ONLY FADES OUT THE CURRENT IMAGE
            FadeOut.From = 1.0;
            FadeOut.To = 0.0;
            FadeOut.Duration = new Duration(TimeSpan.FromSeconds(.5));
            SFadeOut.Children.Add(FadeOut);
            Storyboard.SetTargetName(FadeOut, TheBackground.Name);
            Storyboard.SetTargetProperty(FadeOut, new PropertyPath(Image.OpacityProperty));

            SFadeOut.Begin(this);
        }
        private void ButtonChoice2(object sender, RoutedEventArgs e)
        {
            UserChoice = 2;

        }
        private void ButtonChoice3(object sender, RoutedEventArgs e)
        {
            UserChoice = 3;
        }
        private void ButtonChoice4(object sender, RoutedEventArgs e)
        {
            //This is for giving questions to the player in the beginning of the game
        }
        //==============================================================================


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


    }
}
