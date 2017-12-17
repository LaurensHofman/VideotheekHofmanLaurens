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
        /// <summary>
        /// Sets the event for when the DVD model has to be saved.
        /// </summary>
        /// <param name="model"></param>
        public delegate void ModelSavedEventHandler(DVD model);
        public event ModelSavedEventHandler OnModelSaved;

        /// <summary>
        /// Sets the DVD model used by the current form.
        /// </summary>
        public DVD Model { get; private set; }

        /// <summary>
        /// Default constructor that makes a new DVD model for when no DVD model has been sent.
        /// </summary>
        public DVDForm() : this(new DVD()) { }

        /// <summary>
        /// Default constructor, for when the DVDForm is loaded.
        /// </summary>
        /// <param name="model"></param>
        public DVDForm(DVD model)
        {
            InitializeComponent();
            this.Model = model;      
            grdDVDForm.DataContext = this;
            SetTitle();
        }

        /// <summary>
        /// Sets the title and the content of the submit button.
        /// </summary>
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

        #region Save/Update DVD model and validation of input

        /// <summary>
        /// Saves/Updates the model of the DVD, after validating the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (BL_DVD.Save(Model))
                    {
                        if (OnModelSaved != null)
                            OnModelSaved(Model);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Saving the DVD was unsuccesful, please only enter valid data.", "Save unsuccesful", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Saves the model of the DVD, after validating the input and opens a new DVD form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveNewDVD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (BL_DVD.Save(Model))
                    {
                        this.Content = new DVDForm();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Saving the DVD was unsuccesful, please only enter valid data.", "Save unsuccesful", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Validates the values from the textboxes to avoid errors in the DVD Model
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            bool validation = true;

            #region Hides error labels

            lblNameError.Visibility = Visibility.Collapsed;
            lblStockError.Visibility = Visibility.Collapsed;
            lblPriceError.Visibility = Visibility.Collapsed;
            lblPEGIError.Visibility = Visibility.Collapsed;
            lblDurationEpisodesError.Visibility = Visibility.Collapsed;

            #endregion

            #region Validates to avoid possible entity errors

            #region Validates name
            if (string.IsNullOrWhiteSpace(Model.Name))
            {
                lblNameError.Content = "Cannot be empty";
                lblNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Name.Length > 255)
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
            else if (!int.TryParse(txtStock.Text, out int result))
            {
                lblStockError.Content = "Has to be a whole number";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Stock < 0)
            {
                lblStockError.Content = "Cannot be below 0";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Stock > 99999)
            {
                lblStockError.Content = "Cannot be higher than 99999";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;
            }
            if (Model.Stock < Model.ReservedAmount)
            {
                lblStockError.Content = $"Cannot be lower than the reserved amount ({Model.ReservedAmount})";
                lblStockError.Visibility = Visibility.Visible;
                validation = false;                   
            }
            #endregion

            #region Validates Price
            double priceresult = 0;
            string priceText = txtPrice.Text.Replace("€", "").Replace(" ", "").Replace(".","") ;

            if (string.IsNullOrWhiteSpace(priceText))
            {
                lblPriceError.Content = "Cannot be empty";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (!double.TryParse(priceText, out priceresult))
            {
                lblPriceError.Content = "Has to be a valid number";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Price < 0)
            {
                lblPriceError.Content = "Cannot be below € 0.00";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Price > 99999)
            {
                lblPriceError.Content = "Cannot be over € 99999.00";
                lblPriceError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #region Validates PEGI age
            if (!string.IsNullOrWhiteSpace(txtPEGI.Text))
            {
                if (!int.TryParse(txtPEGI.Text, out int result))
                {
                    lblPEGIError.Content = "Has to be a whole number";
                    lblPEGIError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.PEGIage < 0)
                {
                    lblPEGIError.Content = "Cannot be below 0";
                    lblPEGIError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.PEGIage > 21)
                {
                    lblPEGIError.Content = "PEGI age doesn't go over 21";
                    lblPEGIError.Visibility = Visibility.Visible;
                    validation = false;
                }
                 
            }
            #endregion

            #region Validates MovieDuration
            if (!string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                if (!int.TryParse(txtDuration.Text, out int result))
                {
                    lblDurationEpisodesError.Content = "Has to be a whole number";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.MovieDuration < 0)
                {
                    lblDurationEpisodesError.Content = "Cannot be below 0";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.MovieDuration > 99999)
                {
                    lblDurationEpisodesError.Content = "Cannot be over 99999";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }

            }
            #endregion

            #region Validates TVSeriesEpisodes
            if (!string.IsNullOrWhiteSpace(txtEpisodes.Text))
            {
                if (!int.TryParse(txtEpisodes.Text, out int result))
                {
                    lblDurationEpisodesError.Content = "Has to be a whole number";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.SeriesEpisodes < 0)
                {
                    lblDurationEpisodesError.Content = "Cannot be below 0";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }
                else if (Model.SeriesEpisodes > 99999)
                {
                    lblDurationEpisodesError.Content = "Cannot be over 99999";
                    lblDurationEpisodesError.Visibility = Visibility.Visible;
                    validation = false;
                }

            }
            #endregion

            #endregion

            return validation;
        }

        #endregion

        /// <summary>
        /// Shows/hides the situational textboxes (Duration and Episodes)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxDVDType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxDVDType.SelectedItem == cmbxiTVSeries)
            {
                lblDurationOrEpisodes.Content = "Amount of episodes: ";
                txtDuration.Visibility = Visibility.Collapsed;
                txtEpisodes.Visibility = Visibility.Visible;
                txtDuration.Text = null;
            }
            if (cmbxDVDType.SelectedItem == cmbxiMovie)
            {
                lblDurationOrEpisodes.Content = "Total playtime (minutes): ";
                txtDuration.Visibility = Visibility.Visible;
                txtEpisodes.Visibility = Visibility.Collapsed;
                txtEpisodes.Text = null;
            }
           
        }
    }
}
