using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideotheekLibrary.Entities;

namespace VideotheekHofmanLaurens
{
    /// <summary>
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow()
        {
            InitializeComponent();
            SetTitle();
        }
        
        #region Set Title

        private const string TITLE = "'t Videotheeksken";

        private void SetTitleByRibbonButton(object sender)
        {
            SetTitle(((RibbonButton)sender).Label);
        }

        private void SetTitle(string label = null)
        {
            string _title = "";
            if (!string.IsNullOrWhiteSpace(label))
            {
                _title += label + " - ";
            }

            _title += TITLE;
            this.Title = _title;
        }
        #endregion

        #region CloseWindow
        private void ramiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Are you sure you want to exit?", "Exit program?", MessageBoxButton.YesNo)
                    == MessageBoxResult.No);
        }
        #endregion

        #region DVD Form and Overview

        private void rbtnAddDVD_Click(object sender, RoutedEventArgs e)
        {
            SetTitleByRibbonButton(sender);

            var _form = new DVDForm();
            _form.OnModelSaved += DVDForm_OnModelSaved;
            
            mainControl.Content = _form;
        }
        
        private void rbtnOverviewDVD_Click(object sender, RoutedEventArgs e)
        {
            SetTitleByRibbonButton(sender);

            var _overview = new DVDOverview();
            _overview.OnUpdateDVD += DVDOverview_OnUpdateDVD;

            mainControl.Content = _overview;
        }

        private void DVDOverview_OnUpdateDVD(DVD model)
        {
            SetTitle("Edit DVD");

            DVDForm _form = new DVDForm(model);
            _form.OnModelSaved += DVDForm_OnModelSaved;

            mainControl.Content = _form;
        }

        private void DVDForm_OnModelSaved(DVD model)
        {
            rbtnOverviewDVD_Click(rbtnOverviewDVD, null);
        }

        #endregion

        #region Client Form and Overview
        private void rbtnAddClients_Click(object sender, RoutedEventArgs e)
        {
            var _form = new ClientForm();
            _form.OnModelSaved += ClientForm_OnModelSaved;

            mainControl.Content = _form;
        }  

        private void rbtnClientOverview_Click(object sender, RoutedEventArgs e)
        {
            SetTitleByRibbonButton(sender);

            var _overview = new ClientOverview();
            _overview.OnUpdateClient += ClientOverview_OnUpdateClient;

            mainControl.Content = _overview;
        }

        private void ClientOverview_OnUpdateClient(Client model)
        {
            SetTitle("Edit client");

            ClientForm _form = new ClientForm(model);
            _form.OnModelSaved += ClientForm_OnModelSaved;

            mainControl.Content = _form;
        }

        private void ClientForm_OnModelSaved(Client model)
        {
            rbtnClientOverview_Click(rbtnClientOverview, null);
        }

        #endregion


    }
}
