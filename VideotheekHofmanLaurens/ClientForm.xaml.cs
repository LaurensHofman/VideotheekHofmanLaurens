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
                string birthDate = $"{txtBirthDay.Text}/{txtBirthMonth.Text}/{txtBirthYear.Text}" ;
                Model.BirthDate = Convert.ToDateTime(birthDate);

                if (BL_Client.Save(Model))
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
    }
}
