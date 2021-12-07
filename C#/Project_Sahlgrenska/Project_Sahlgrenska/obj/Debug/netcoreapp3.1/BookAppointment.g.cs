﻿#pragma checksum "..\..\..\BookAppointment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87AFE91B07B6AD8FB0E3BA9871636E93A28E65B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_Sahlgrenska;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Project_Sahlgrenska {
    
    
    /// <summary>
    /// BookAppointment
    /// </summary>
    public partial class BookAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bookingPatient;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bookingDoctor;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel bookingEquipment;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel bookingMeds;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker bookingDate;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookingReason;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookingTime;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableRooms;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\BookAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pageInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project_Sahlgrenska;component/bookappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BookAppointment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bookingPatient = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\BookAppointment.xaml"
            this.bookingPatient.GotFocus += new System.Windows.RoutedEventHandler(this.bookingPatient_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bookingDoctor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\BookAppointment.xaml"
            this.bookingDoctor.GotFocus += new System.Windows.RoutedEventHandler(this.bookingDoctor_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bookingEquipment = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.bookingMeds = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.bookingDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.bookingReason = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.bookingTime = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\BookAppointment.xaml"
            this.bookingTime.GotFocus += new System.Windows.RoutedEventHandler(this.bookingTime_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.availableRooms = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\BookAppointment.xaml"
            this.availableRooms.GotFocus += new System.Windows.RoutedEventHandler(this.availableRooms_GotFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 37 "..\..\..\BookAppointment.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.pageInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

