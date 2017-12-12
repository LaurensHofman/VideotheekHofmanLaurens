using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace VideotheekHofmanLaurens
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        bool showPassword;

        public LoginWindow()
        {
            InitializeComponent();
            showPassword = false;
            txtUsername.Focus();

        }
        // Allows to determine whether this window has to close without prompting with a messagebox. For example when the login was succesful.
        bool newWindow = false;

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                new NavigationWindow().Show();
                newWindow = true;
                this.Close();
            }
        }

        private bool Validate()
        {
            bool validation = true;
            
            lblEmptyPassword.Visibility = Visibility.Collapsed;
            lblEmptyUsername.Visibility = Visibility.Collapsed;
            lblWrongCredentials.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblEmptyUsername.Visibility = Visibility.Visible;
                validation = false;
            }

            if (string.IsNullOrWhiteSpace(pwdPassword.Password))
            {
                lblEmptyPassword.Visibility = Visibility.Visible;
                validation = false;
            }

            if (   
                (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(pwdPassword.Password)) 
                &&
                (pwdPassword.Password != "admin" || txtUsername.Text.ToLower() != "admin") 
               )
            {
                lblWrongCredentials.Visibility = Visibility.Visible;
                validation = false;
            }

            pwdPassword.Password = "";

            return validation;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void wndLoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (newWindow == false)
            {
                e.Cancel = (MessageBox.Show("Are you sure you want to exit?", "Exit program?", MessageBoxButton.YesNo)
                    == MessageBoxResult.No);
            }
            else
            {
                e.Cancel = false;
            }

        }

        private void btnShowHidePassword_Click(object sender, RoutedEventArgs e)
        {
            if (btnShowHidePassword.Content == FindResource("Show"))
                btnShowHidePassword.Content = FindResource("Hide");

            else
                btnShowHidePassword.Content = FindResource("Show");


            if (showPassword == false)
                showPassword = true;
            else
                showPassword = false;


            ToggleShowPassword();
        }

        private void ToggleShowPassword()
        {
            pwdPassword.Visibility = Visibility.Collapsed;
            txtPasswordVisible.Visibility = Visibility.Collapsed;

            if (showPassword)
            {
                txtPasswordVisible.Visibility = Visibility.Visible;
                txtPasswordVisible.Focus();
            }
            else
            {
                pwdPassword.Visibility = Visibility.Visible;
                pwdPassword.Focus();
            }
        }

        private void txtPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            pwdPassword.Password = txtPasswordVisible.Text;
            int start = txtPasswordVisible.Text.Length;
            int length = 0;
            txtPasswordVisible.Select(start, length);
        }

        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = pwdPassword.Password;
            int start = pwdPassword.Password.Length;
            int length = 0;
            pwdPassword.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(pwdPassword, new object[] { start, length });
        }
        
    }
}
