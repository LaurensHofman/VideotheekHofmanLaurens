using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (Validate())
            {
                try
                {
                    if (BL_DVD.Save(Model))
                    {
                        if (OnModelSaved != null)
                            OnModelSaved(Model);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Validate()
        {
            bool validation = true;

            #region Hides error labels

            lblNameError.Visibility = Visibility.Collapsed;
            lblStockError.Visibility = Visibility.Collapsed;
            lblPriceError.Visibility = Visibility.Collapsed;

            #endregion

            #region Avoids possible entity errors

            #region Validates name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameError.Content = "Cannot be empty";
                lblNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (txtName.Text.Length > 255)
            {
                lblNameError.Content = "Cannot be longer than 255 characters";
                lblNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #region Validates stock
            if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                lblStockError.Content = "Cannot be empty";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (!Int32.TryParse(txtStock.Text, out int number))
            {
                lblStockError.Content = "Has to be a whole number";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            
            else if (Model.Stock < 0)
            {
                lblStockError.Content = "Cannot be below 0";
                lblNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (int.Parse(txtStock.Text) > 99999)
            {
                lblStockError.Content = "Cannot be higher than 99999";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #region Validates Price
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblPriceError.Content = "Cannot be empty";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Price < (decimal)0.00)
            {
                lblPriceError.Content = "Cannot be below € 0.00";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #endregion

            return validation;
        }

        /// <summary>
        /// Shows/hides the situational textboxes (Duration and Episodes)
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
                txtDuration.Text = "";
            }
            if (cmbDVDType.SelectedItem == cmbiMovie)
            {
                lblDurationOrEpisodes.Content = "Total playtime (minutes): ";
                txtDuration.Visibility = Visibility.Visible;
                txtEpisodes.Visibility = Visibility.Collapsed;
                txtEpisodes.Text = "";
            }
           
        }
        
        /// <summary>
        /// Selects all the text in the textbox when switched to with TAB for those with a standard 0 filled in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Selection on tab
        private void txtStock_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }

        private void txtPrice_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                ((TextBox)sender).SelectAll();
        }
        #endregion
    }
}
