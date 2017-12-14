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
        /// <summary>
        /// Default constructor, for when the NavigationWindow is loaded.
        /// </summary>
        public NavigationWindow()
        {
            InitializeComponent();
            SetTitle();
        }

        #region Set Title

        /// <summary>
        /// Constant part of the window title.
        /// </summary>
        private const string TITLE = "'t Videotheeksken";

        /// <summary>
        /// Gets the content of the label (of pressed the button) to use it in the window title.
        /// </summary>
        /// <param name="sender"></param>
        private void SetTitleByRibbonButton(object sender)
        {
            SetTitle(((RibbonButton)sender).Label);
        }

        /// <summary>
        /// Sets the title of the window.
        /// </summary>
        /// <param name="label"></param>
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

        /// <summary>
        /// Closes the window when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ramiExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the closing of the whole window, called when manually closed through a button or control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Are you sure you want to exit?", "Exit program?", MessageBoxButton.YesNo)
                    == MessageBoxResult.No);
        }

        #endregion

        #region DVD Form and Overview

        /// <summary>
        /// Changes the content of the window to a form to add new DVD's.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAddDVD_Click(object sender, RoutedEventArgs e)
        {
            SetTitleByRibbonButton(sender);

            var _form = new DVDForm();
            _form.OnModelSaved += DVDForm_OnModelSaved;
            
            mainControl.Content = _form;
        }
        
        /// <summary>
        /// Changes the content of the window to an overview of the DVD's.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnOverviewDVD_Click(object sender, RoutedEventArgs e)
        {
            SetTitleByRibbonButton(sender);

            var _overview = new DVDOverview();
            _overview.OnUpdateDVD += DVDOverview_OnUpdateDVD;

            mainControl.Content = _overview;
        }

        /// <summary>
        /// Opens a DVD form when wanting to update the DVD through the DVD overview.
        /// </summary>
        /// <param name="model"></param>
        private void DVDOverview_OnUpdateDVD(DVD model)
        {
            SetTitle("Edit DVD");

            DVDForm _form = new DVDForm(model);
            _form.OnModelSaved += DVDForm_OnModelSaved;

            mainControl.Content = _form;
        }

        /// <summary>
        /// Opens the dvd overview, whenever a DVD is saved in a DVD form.
        /// </summary>
        /// <param name="model"></param>
        private void DVDForm_OnModelSaved(DVD model)
        {
            rbtnOverviewDVD_Click(rbtnOverviewDVD, null);
        }

        #endregion
    }
}
