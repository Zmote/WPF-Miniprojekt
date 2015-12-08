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
using System.Windows.Threading;

namespace ch.hsr.wpf.gadgeothek.ui
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public string CurrentUrl { get; set; }
        public LibraryAdminService alibService = new LibraryAdminService("http://mge2.dev.ifs.hsr.ch/");
        public ObservableCollection<Gadget> Gadgets { get; set; }
        public ObservableCollection<Loan> Loans { get; set; }
        public ObservableCollection<Reservation> Reservations { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<string> Bibliotheken { get; set; }
        private DispatcherTimer dispatcherTimer;
        public WindowMain()
        {
            InitializeComponent();
            InitCollections();
            InitTimer();
            DataContext = this;  
        }

        ////-------------------//
        ///--Event Functions--//
        //-------------------//

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (checkForUpdates())
            {
                RefreshDataGrid();
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGadgets();
        }

        private void Reservations_GotFocus(object sender, RoutedEventArgs e)
        {
            HideButtons();
            LoadReservations();
        }
        
        private void Loans_GotFocus(object sender, RoutedEventArgs e)
        {
            HideButtons();
            LoadLoans();
        }

        private void Gadgets_GotFocus(object sender, RoutedEventArgs e)
        {
            ShowButtons();
            LoadGadgets();
        }

        private void Customers_GotFocus(object sender, RoutedEventArgs e)
        {
            HideButtons();
            LoadCustomers();
        }

        private void ComboList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboList.SelectedItem.ToString() == CurrentUrl)
            {
                return;
            }
            alibService.ServerUrl = ComboList.SelectedItem.ToString();
            CurrentUrl = ComboList.SelectedItem.ToString();
            EmptyContainers();
            RefreshDataGrid();
        }
        

        private void NewGadget_Click(object sender, RoutedEventArgs e)
        {
            NewGadget ng_window = new NewGadget();
            ng_window.Show();
        }

        private void DeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget toDelete = GadgetsData.SelectedItem as Gadget;
            if (toDelete == null)
            {
                return;
            }
            Alert myAlert = new Alert();
            myAlert.SelectedGadget = toDelete;
            myAlert.Show();
        }

        ////---------------------------------//
        ///--Initializing Helper Functions--//
        //---------------------------------//

        private void InitCollections()
        {
            CurrentUrl = "http://mge2.dev.ifs.hsr.ch/";
            Gadgets = new ObservableCollection<Gadget>();
            Loans = new ObservableCollection<Loan>();
            Reservations = new ObservableCollection<Reservation>();
            Customers = new ObservableCollection<Customer>();
            Bibliotheken = new ObservableCollection<string>();
            InitBibliotheken();
        }

        private void InitTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void InitBibliotheken()
        {
            for (int i = 1; i <= 10; i++)
            {
                Bibliotheken.Add("http://mge" + i + ".dev.ifs.hsr.ch/");
            }
            ComboList.SelectedIndex = 1;
        }

        ////---------------------------//
        ///--Load Helper Functions----//
        //---------------------------//

        private void LoadGadgets()
        {
            List<Gadget> mylist = alibService.GetAllGadgets();
            if (mylist.Count > Gadgets.Count)
            {
                Gadgets.Clear();
                foreach (Gadget gadget in mylist)
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

        private void EmptyContainers()
        {
            Gadgets.Clear();
            Reservations.Clear();
            Loans.Clear();
            Customers.Clear();
        }

        ////---------------------------//
        ///--Button Helper Functions--//
        //---------------------------//

        private void HideButtons()
        {
            NewGadgetBtn.Visibility = Visibility.Hidden;
            DeleteGadgetBtn.Visibility = Visibility.Hidden;
        }

        private void ShowButtons()
        {
            NewGadgetBtn.Visibility = Visibility.Visible;
            DeleteGadgetBtn.Visibility = Visibility.Visible;
        }

        ////---------------------------//
        ///--Update Helper Functions--//
        //---------------------------//

        public void RefreshDataGrid()
        {
            EmptyContainers();
            LoadGadgets();
            LoadReservations();
            LoadLoans();
            LoadCustomers();
        }

        private bool checkForUpdates()
        {                      
            switch ((Tabs.SelectedItem as TabItem).Header.ToString())
            {
                case "Gadgets":
                    return checkGadgetsForUpdate();
                case "Reservations":
                    return checkReservationsForUpdate();
                case "Loans":
                    Debug.WriteLine("Loans update:{0}", checkLoansForUpdate());
                    return checkLoansForUpdate();
                case "Customers":
                    return checkCustomersForUpdate();
                default:
                    return false;
            }
        }

        private bool checkGadgetsForUpdate()
        {
            List<Gadget> myGadgets = alibService.GetAllGadgets();
            Gadgets.ToList();
            if (Gadgets == null)
            {
                return true;
            }
            if (!CompareContents<List<Gadget>, Gadget>(Gadgets.ToList(), myGadgets))
            {
                return true;
            }
            return false;
        }

        private bool checkReservationsForUpdate()
        {
            List<Reservation> myReservations = alibService.GetAllReservations();
            if (Reservations == null)
            {
                return true;
            }
            if (!CompareContents<List<Reservation>, Reservation>(Reservations.ToList(), myReservations))
            {
                return true;
            }
            return false;
        }

        private bool checkLoansForUpdate()
        {
            List<Loan> myLoans = alibService.GetAllLoans();
            if (Loans == null)
            {
                return true;
            }
            if (!CompareContents<List<Loan>, Loan>(Loans.ToList(), myLoans))
            {
                return true;
            }
            return false;
        }

        private bool checkCustomersForUpdate()
        {
            List<Customer> myCustomers = alibService.GetAllCustomers();
            if (Customers == null)
            {
                return true;
            }
            if (!CompareContents<List<Customer>, Customer>(Customers.ToList(), myCustomers))
            {
                return true;
            }
            return false;
        }

        private bool CompareContents<T, U>(T origin, T target)
            where T : List<U>
        {
            int size = origin.Count;
            if (origin.Count != target.Count)
            {
                return false;
            }
            for (int i = 0; i < size; i++)
            {
                if (!origin[i].Equals(target[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
