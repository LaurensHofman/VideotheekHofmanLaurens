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
        /// <summary>
        /// Default constructor, for when the LoginWindow is loaded
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();
            showPassword = false;
            txtUsername.Focus();
        }

        /// <summary>
        /// Allows to determine whether this window has to close without prompting with a messagebox. For example when the login was succesful.
        /// </summary>
        bool newWindow = false;

        /// <summary>
        /// Allows to determine whether the button (to switch between visible and hidden password has to show or hide the password.
        /// </summary>
        bool showPassword;

        /// <summary>
        /// Attempts to login after validating the given credentials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                new NavigationWindow().Show();
                newWindow = true;
                this.Close();
            }
        }

        /// <summary>
        /// Validates the given credentials
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            bool validation = true;

            #region Hides error labels

            lblEmptyPassword.Visibility = Visibility.Collapsed;
            lblEmptyUsername.Visibility = Visibility.Collapsed;
            lblWrongCredentials.Visibility = Visibility.Collapsed;

            #endregion

            #region Validates login credentials

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

            #endregion

            pwdPassword.Password = "";

            return validation;
        }
        
        #region Close window

        /// <summary>
        /// Closes the window when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the closing of the whole window, called when manually closed through a button or a control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion

        #region Toggle Password

        /// <summary>
           /// Determines whether the password has to be shown, and toggles the icon in the button to the appropriate image.
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
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

        /// <summary>
        /// Toggles the visibility of the PasswordBox to show the hidden password and the visibility of the TextBox to show the visible password.
        /// </summary>
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

        /// <summary>
        /// Whenever the text is changed in the textbox, it will synchronize with the password box and put the text cursor at the end of the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPasswordVisible_TextChanged(object sender, TextChangedEventArgs e)
        {
            pwdPassword.Password = txtPasswordVisible.Text;
            int start = txtPasswordVisible.Text.Length;
            int length = 0;
            txtPasswordVisible.Select(start, length);
        }

        /// <summary>
        /// Whenever the text is changed in the passwordbox, it will synchronize with the textbox and put the text cursor at the end of the passwordbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pwdPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = pwdPassword.Password;
            int start = pwdPassword.Password.Length;
            int length = 0;
            pwdPassword.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(pwdPassword, new object[] { start, length });
        }

        #endregion
    }
}
