using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        private LibraryAdminService alibService = new LibraryAdminService("http://mge2.dev.ifs.hsr.ch/");
        public ObservableCollection<Gadget> Gadgets { get; set; }
        public ObservableCollection<Loan> Loans { get; set; }
        public ObservableCollection<Reservation> Reservations { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public WindowMain()
        {
            InitializeComponent();
            DataContext = this;
            Gadgets = new ObservableCollection<Gadget>();
            Loans = new ObservableCollection<Loan>();
            Reservations = new ObservableCollection<Reservation>();
            Customers = new ObservableCollection<Customer>();
        }

        private void LoadGadgets()
        {
            List<Gadget> mylist = alibService.GetAllGadgets();
            if(mylist.Count > Gadgets.Count)
            {
                Gadgets.Clear();            
                foreach(Gadget gadget in mylist)
                {
                    Gadgets.Add(gadget);
                }
            }

        }

        private void LoadLoans()
        {
            List<Loan> mylist = alibService.GetAllLoans();
            if (mylist.Count > Loans.Count)
            {
                Loans.Clear();
                foreach (Loan loan in mylist)
                {
                    Loans.Add(loan);
                }
            }

        }

        private void LoadReservations()
        {
            List<Reservation> mylist = alibService.GetAllReservations();
            if (mylist.Count > Reservations.Count)
            {
                Reservations.Clear();
                foreach (Reservation reservation in mylist)
                {
                    Reservations.Add(reservation);
                }
            }

        }

        private void LoadCustomers()
        {
            List<Customer> mylist = alibService.GetAllCustomers();
            if (mylist.Count > Customers.Count)
            {
                Customers.Clear();
                foreach (Customer customer in mylist)
                {
                    Customers.Add(customer);
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGadgets();
        }

        private void Reservations_GotFocus(object sender, RoutedEventArgs e)
        {
            LoadReservations();
        }

        private void Loans_GotFocus(object sender, RoutedEventArgs e)
        {
            LoadLoans();
        }

        private void Gadgets_GotFocus(object sender, RoutedEventArgs e)
        {
            LoadGadgets();
        }

        private void Customers_GotFocus(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
        }
    }
}
