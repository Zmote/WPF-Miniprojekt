﻿#pragma checksum "..\..\WindowMain.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "352EDC716ED98291F218B8F20B212D98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using ch.hsr.wpf.gadgeothek.ui;


namespace ch.hsr.wpf.gadgeothek.ui {
    
    
    /// <summary>
    /// WindowMain
    /// </summary>
    public partial class WindowMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewGadgetBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteGadgetBtn;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboList;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GadgetsData;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LoansData;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ReservationsData;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\WindowMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomersData;
        
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
            System.Uri resourceLocater = new System.Uri("/ch.hsr.wpf.gadgeothek.ui;component/windowmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowMain.xaml"
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
            
            #line 10 "..\..\WindowMain.xaml"
            ((ch.hsr.wpf.gadgeothek.ui.WindowMain)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NewGadgetBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\WindowMain.xaml"
            this.NewGadgetBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteGadget_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteGadgetBtn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\WindowMain.xaml"
            this.DeleteGadgetBtn.Click += new System.Windows.RoutedEventHandler(this.NewGadget_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\WindowMain.xaml"
            this.ComboList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 70 "..\..\WindowMain.xaml"
            ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Gadgets_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GadgetsData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            
            #line 80 "..\..\WindowMain.xaml"
            ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Loans_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LoansData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 89 "..\..\WindowMain.xaml"
            ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Reservations_GotFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ReservationsData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            
            #line 98 "..\..\WindowMain.xaml"
            ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Customers_GotFocus);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CustomersData = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

