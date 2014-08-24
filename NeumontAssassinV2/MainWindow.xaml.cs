﻿using System;
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
using NeumontAssassinV2.Missions;
using NeumontAssassinV2.Models;

namespace NeumontAssassinV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainGrid.Children.Clear();
            Person p = new Person();
            ////for testing purposes:
            p.Player_Agility = 3;
            p.Player_Charisma = 5;
            p.Player_Intellegence = 5;
            p.Player_Strength = 5;
            p.Player_Name = "Test1";
            DrugLord dl = new DrugLord(p);
            MainGrid.Children.Add(dl);
        }
    }
}
