using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentResource;
        public MainWindow()
        {
            InitializeComponent();
            Resources = new ResourceDictionary();
            if (Main.Width > 400)
            {
                currentResource = "DesktopResources";
                changeSkin(currentResource);
            }
            else
            {
                currentResource = "MobileResources";
                changeSkin(currentResource);
            }
        }

        private void changeSkin(string skinName)
        {
            // clear all items in the resource dic of the current window
            Resources.Clear();
            // additionally, clear all contained merged dics
            Resources.MergedDictionaries.Clear();
            // somehow get the new skin name...
            var newSkinName = skinName;
            // prepare the uri (skins are located in folder „skin“)
            var uri = new Uri($"resources/{newSkinName}.xaml", UriKind.Relative);
            // load the new skin
            var skin = Application.LoadComponent(uri) as ResourceDictionary;
            // now add the new skino the window’s resources
            Resources.MergedDictionaries.Add(skin);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Debug.WriteLine("CurrentResource: {0}, Main.Width: {1}", currentResource, Main.Width);
            if(Main.Width < 400)
            {
                if(currentResource != "MobileResources")
                {
                    currentResource = "MobileResources";
                    MenuBarLeft.Visibility = Visibility.Collapsed;
                    changeSkin(currentResource);
                }
            }
            if(Main.Width > 400)
            {
                if(currentResource != "DesktopResources")
                {
                    currentResource = "DesktopResources";
                    MenuBarLeft.Visibility = Visibility.Visible;
                    changeSkin(currentResource);
                }
                
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(MenuBarLeft.Visibility == Visibility.Collapsed)
            {
                MenuBarLeft.Visibility = Visibility.Visible;
                MenuBarLeft.Width = double.NaN; 
                Content.Visibility = Visibility.Collapsed;
            }
            else
            {
                MenuBarLeft.Visibility = Visibility.Collapsed;
                MenuBarLeft.Width = 250;
                Content.Visibility = Visibility.Visible;
            }
        }
    }
}
