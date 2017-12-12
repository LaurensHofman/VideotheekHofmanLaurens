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
    /// Interaction logic for ClientForm.xaml
    /// </summary>
    public partial class ClientForm : UserControl
    {
        private void txtBirthDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBirthDay.Text.Length == 2)
            {
                txtBirthMonth.Focus();
            }
        }

        private void txtBirthMonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBirthMonth.Text.Length == 2)
            {
                txtBirthYear.Focus();
            }
        }

        public delegate void ModelSavedEventHandler(Client model);

        public event ModelSavedEventHandler OnModelSaved;

        public Client Model { get; private set; }

        public ClientForm() : this(new Client()) { }

        public ClientForm(Client model)
        {
            InitializeComponent();

            this.Model = model;

            if (model.BirthDate != null)
            {
                txtBirthDay.Text = (model.BirthDate.Value.Day < 10) ? "0" + model.BirthDate.Value.Day.ToString() : model.BirthDate.Value.Day.ToString();
                txtBirthMonth.Text = (model.BirthDate.Value.Month < 10) ? "0" + model.BirthDate.Value.Month.ToString() : model.BirthDate.Value.Month.ToString();
                txtBirthYear.Text = model.BirthDate.Value.Year.ToString();
            }

            grdClientForm.DataContext = this;

            SetTitle();
        }

        private void SetTitle()
        {
            if (Model.IsNew())
            {
                lblTitle.Content = "New client";
                btnSave.Content = "Save";
            }
            else
            {
                lblTitle.Content = "Edit client";
                btnSave.Content = "Update";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    string birthDate = $"{txtBirthDay.Text}/{txtBirthMonth.Text}/{txtBirthYear.Text}";
                    Model.BirthDate = Convert.ToDateTime(birthDate);

                    if (BL_Client.Save(Model))
                    {
                        if (OnModelSaved != null)
                            OnModelSaved(Model);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool Validate()
        {
            bool validation = true;

            #region Hides error labels

            lblSurnameError.Visibility = Visibility.Collapsed;
            lblFirstNameError.Visibility = Visibility.Collapsed;
            lblBirthDateError.Visibility = Visibility.Collapsed;
          
            #endregion

            #region Validates to avoid possible entity errors

            #region Validates surname
            if (string.IsNullOrWhiteSpace(Model.Surname))
            {
                lblSurnameError.Content = "Cannot be empty";
                lblSurnameError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.Surname.Length > 255)
            {
                lblSurnameError.Content = "Cannot be longer than 255 characters";
                lblSurnameError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #region Validates first name
            if (string.IsNullOrWhiteSpace(Model.FirstName))
            {
                lblFirstNameError.Content = "Cannot be empty";
                lblFirstNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            else if (Model.FirstName.Length > 255)
            {
                lblFirstNameError.Content = "Cannot be longer than 255 characters";
                lblFirstNameError.Visibility = Visibility.Visible;
                validation = false;
            }
            #endregion

            #region Validates birth date

            try
            {
                string birthDate = $"{txtBirthDay.Text}/{txtBirthMonth.Text}/{txtBirthYear.Text}";
                Model.BirthDate = Convert.ToDateTime(birthDate);

                if (Model.BirthDate >= DateTime.Now)
                {
                    lblBirthDateError.Visibility = Visibility.Visible;
                    lblBirthDateError.Content = "Birth date cannot be in the future";
                    validation = false;
                }
            }
            catch (Exception)
            {
                lblBirthDateError.Visibility = Visibility.Visible;
                lblBirthDateError.Content = "Enter a valid birthdate";
                validation = false;
            }
            
            #endregion

            #endregion

            return validation;
        }
    }
}
