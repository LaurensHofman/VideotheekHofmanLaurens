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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideotheekLibrary.BL;
using VideotheekLibrary.Entities;

namespace VideotheekHofmanLaurens
{
    /// <summary>
    /// Interaction logic for DVDForm.xaml
    /// </summary>
    public partial class DVDForm : UserControl
    {
        public delegate void ModelSavedEventHandler(DVD model);

        public event ModelSavedEventHandler OnModelSaved;

        public DVD Model { get; private set; }

        public DVDForm() : this(new DVD()) { }

        public DVDForm(DVD model)
        {
            InitializeComponent();

            this.Model = model;
      
            grdDVDForm.DataContext = this;

            SetTitle();
        }

        private void SetTitle()
        {
            if (Model.IsNew())
            {
                lblTitle.Content = "New DVD";
                btnSave.Content = "Save";
            }
            else
            {
                lblTitle.Content = "Edit DVD";
                btnSave.Content = "Update";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BL_DVD.Save(Model))
                {
                    if (OnModelSaved != null)
                        OnModelSaved(Model);
                }
                MessageBox.Show("You saved");
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Shows/hides the situational textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDVDType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDVDType.SelectedItem == cmbiTVSeries)
            {
                lblDurationOrEpisodes.Content = "Amount of episodes: ";
                txtDuration.Visibility = Visibility.Collapsed;
                txtEpisodes.Visibility = Visibility.Visible;
            }
            if (cmbDVDType.SelectedItem == cmbiMovie)
            {
                lblDurationOrEpisodes.Content = "Total playtime (minutes): ";
                txtDuration.Visibility = Visibility.Visible;
                txtEpisodes.Visibility = Visibility.Collapsed;
            }
           
        }


        /// <summary>
        /// Selects all the text in the textbox when switched to with TAB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Selection on tab
        private void txtStock_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        private void txtPricePerDay_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        private void txtDuration_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        private void txtEpisodes_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }
        #endregion
    }
}
