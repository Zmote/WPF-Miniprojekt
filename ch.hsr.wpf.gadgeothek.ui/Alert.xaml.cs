using ch.hsr.wpf.gadgeothek.domain;
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
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for Alert.xaml
    /// </summary>
    public partial class Alert : Window
    {
        public Gadget SelectedGadget { get; set; }
        public Alert()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            WindowMain mainWindow = (WindowMain)Application.Current.MainWindow;
            mainWindow.alibService.DeleteGadget(SelectedGadget);
            mainWindow.RefreshDataGrid();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
