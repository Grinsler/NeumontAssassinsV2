﻿#pragma checksum "..\..\..\Missions\DrugLord.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7740A83EEF31DD4F2F9A358ED1010581"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NeumontAssassinV2.Missions {
    
    
    /// <summary>
    /// DrugLord
    /// </summary>
    public partial class DrugLord : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label picLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label testLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label testLabe2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but1;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but2;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Missions\DrugLord.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but3;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NeumontAssassinV2;component/missions/druglord.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Missions\DrugLord.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.picLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.testLabel = ((System.Windows.Controls.Label)(target));
            
            #line 30 "..\..\..\Missions\DrugLord.xaml"
            this.testLabel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CycleDialogue);
            
            #line default
            #line hidden
            return;
            case 3:
            this.testLabe2 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.but1 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Missions\DrugLord.xaml"
            this.but1.Click += new System.Windows.RoutedEventHandler(this.but1_choice);
            
            #line default
            #line hidden
            return;
            case 5:
            this.but2 = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Missions\DrugLord.xaml"
            this.but2.Click += new System.Windows.RoutedEventHandler(this.but2_choice);
            
            #line default
            #line hidden
            return;
            case 6:
            this.but3 = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Missions\DrugLord.xaml"
            this.but3.Click += new System.Windows.RoutedEventHandler(this.but3_choice);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

