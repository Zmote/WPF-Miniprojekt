using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für NewGadget.xaml
    /// </summary>
    public partial class NewGadget : Window
    {
        private Gadget myGadget;
        public NewGadget()
        {            
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            myGadget = new Gadget();
            myGadget.Name = NameInput.Text;
            myGadget.Manufacturer = ManufacturerInput.Text;
            myGadget.Price = double.Parse(PriceInput.Text);
            myGadget.Condition = conditionMapper(ConditionInput.SelectedIndex);
            myGadget.InventoryNumber = INInput.Text;
            WindowMain mainWindow = (WindowMain)Application.Current.MainWindow;
            mainWindow.alibService.AddGadget(myGadget);
            mainWindow.RefreshDataGrid();
            this.Close();

        }

        domain.Condition conditionMapper(int index)
        {
            switch (index)
            {
                case 0:
                    return domain.Condition.New;
                case 1:
                    return domain.Condition.Good;
                case 2:
                     return domain.Condition.Damaged;
                case 3:
                    return domain.Condition.Waste;
                case 4:
                    return domain.Condition.Lost;
                default:
                    return domain.Condition.New;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
