using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ch.hsr.wpf.gadgeothek.ui;
using ch.hsr.wpf.gadgeothek;
using System.Reflection;
using System.IO;
using TestStack.White;
using System.Linq;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.Finders;
using ch.hsr.wpf.gadgeothek.domain;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.Factory;
using System.Diagnostics;
using TestStack.White.UIItems.ListBoxItems;

namespace ch.hsr.wpf.gadgeothek.tests
{
    [TestClass]
    public class WindowMainTests
    {
        public string BaseDir => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string SutPath => Path.Combine(BaseDir, $"ch.hsr.wpf.gadgeothek.ui.exe");
        private Random Rnd = new Random();
        WindowMain mainWindow;

        [TestInitialize]
        public void setup()
        {
            mainWindow = new WindowMain();
        }

        [TestCleanup]
        public void clear()
        {
            mainWindow = null;
        }

        [TestMethod]
        public void TestIfGadgetsIsInitialized()
        {
            Assert.IsNotNull(mainWindow.Gadgets);
        }

        [TestMethod]
        public void TestIfReservationsIsInitialized()
        {
            Assert.IsNotNull(mainWindow.Reservations);
        }

        [TestMethod]
        public void TestIfLoansIsInitialized()
        {
            Assert.IsNotNull(mainWindow.Loans);
        }

        [TestMethod]
        public void TestIfCustomersIsInitialized()
        {
            Assert.IsNotNull(mainWindow.Customers);
        }

        [TestMethod]
        public void TestIfLibraryAdminServcieIsInitialized()
        {
            Assert.IsNotNull(mainWindow.alibService);
        }

        [TestMethod]
        public void TestIfBiblitohekenIsInitialized()
        {
            Assert.IsNotNull(mainWindow.Bibliotheken);
        }

        [TestMethod]
        public void TestIfAllTabsAreSet()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var tabs = window.Get<Tab>("Tabs");
            Assert.AreEqual(tabs.TabCount, 4);
            window.Close();
        }

        [TestMethod]
        public void TestIfGadgetsTabHasContent()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var tabs = window.Get<Tab>("Tabs");
            var gadgetTab = tabs.GetElement(SearchCriteria.ByText("Gadgets"));
            gadgetTab.SetFocus();
            Assert.IsNotNull(gadgetTab.GetSupportedProperties().Length);
            window.Close();
        }

        [TestMethod]
        public void TestAddNewGadgetDialogOpened()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var btn = window.Get<Button>(SearchCriteria.ByText("New Gadget"));
            btn.Click();
            var newGadget = app.GetWindow("NewGadget");
            Assert.IsNotNull(newGadget);
            newGadget.Close();
            window.Close();           
        }

        [TestMethod]
        public void TestDeleteGadgetAlertOpened()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var btn = window.Get<Button>(SearchCriteria.ByText("Delete Gadget"));
            var datagrid = window.Get<ListView>(SearchCriteria.ByAutomationId("GadgetsData"));
            datagrid.Select(0);
            btn.Click();
            var alert = app.GetWindow("Alert");
            Assert.IsNotNull(alert);
            alert.Close();
            window.Close();
            app.Close();
        }
               
        [TestMethod]
        public void TestNewGadgetAdded()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var comboList = window.Get<ComboBox>("ComboList");
            comboList.Items.Select(6);
            var datagrid = window.Get<ListView>(SearchCriteria.ByAutomationId("GadgetsData"));
            var before = datagrid.Rows.Count;
            
            var btn = window.Get<Button>(SearchCriteria.ByText("New Gadget"));
            btn.Click();
            var newGadget = app.GetWindow("NewGadget");
            var name = newGadget.Get<TextBox>("NameInput");
            var manufacturer = newGadget.Get<TextBox>("ManufacturerInput");
            var price = newGadget.Get<TextBox>("PriceInput");
            var inventorynumber = newGadget.Get<TextBox>("INInput");
            name.Text = "CEmilsPhone";
            manufacturer.Text = "CEmilCompany";
            price.Text = "400";
            inventorynumber.Text = $"{Rnd.Next()}u{Rnd.Next()}";
            var btnSubmit = newGadget.Get<Button>("Submit");
            btnSubmit.Click();
            datagrid = window.Get<ListView>(SearchCriteria.ByAutomationId("GadgetsData"));
            var after = datagrid.Rows.Count;
            Assert.AreNotEqual(before, after);
            Assert.IsTrue(before < after);
            window.Close();
            app.Close();
        }

        [TestMethod]
        public void TestDeletionOfGadget()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var comboList = window.Get<ComboBox>("ComboList");
            comboList.Items.Select(6);
            var btn = window.Get<Button>(SearchCriteria.ByText("Delete Gadget"));
            var datagrid = window.Get<ListView>(SearchCriteria.ByAutomationId("GadgetsData"));
            var before = datagrid.Rows.Count;
            datagrid.Select(0);
            btn.Click();
            var alert = app.GetWindow("Alert");
            var btnDelete = alert.Get<Button>("Delete");
            btnDelete.Click();
            datagrid = window.Get<ListView>(SearchCriteria.ByAutomationId("GadgetsData"));
            var after = datagrid.Rows.Count;
            Assert.IsTrue(before > after);
            window.Close();
            app.Close();
        }

        [TestMethod]
        public void TestServerChange()
        {
            var app = Application.Launch(SutPath);
            var window = app.GetWindows().First();
            var comboList = window.Get<ComboBox>("ComboList");
            comboList.Items.Select(5);
            var currentUrl = comboList.SelectedItemText;
            Assert.AreEqual("http://mge6.dev.ifs.hsr.ch/", currentUrl);
            window.Close();
            app.Close();
        }

    }
}
