using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
using VideotheekLibrary.Data;
using VideotheekLibrary.Entities;

namespace VideotheekHofmanLaurens
{
    /// <summary>
    /// Interaction logic for DVDOverview.xaml
    /// </summary>
    public partial class DVDOverview : UserControl
    {
        /// <summary>
        /// Sets the event for when the DVD has to be updated.
        /// </summary>
        /// <param name="model"></param>
        public delegate void UpdateDVD(DVD model);
        public event UpdateDVD OnUpdateDVD;
        
        /// <summary>
        /// A list of DVDs, used as source for the DataGrid.
        /// </summary>
        public ObservableCollection<DVD> dataSource { get; set; }
        /// <summary>
        /// A list of DVDs, used as a source for the DataGrid when filtered.
        /// </summary>
        public ObservableCollection<DVD> filteredSource { get; set; }

        #region Local variables

        /// <summary>
        /// A bool to determine whether the DataGrid is filtered or not.
        /// </summary>
        bool _dataGridIsFiltered;
        /// <summary>
        /// A string that remembers the last used text to filter.
        /// </summary>
        string _filterText;
        /// <summary>
        /// A string that remembers the last used filter category.
        /// </summary>
        string _filterCategory;

        #endregion

        /// <summary>
        /// Default constructor, for when the DVDOverview is loaded.
        /// </summary>
        public DVDOverview()
        {
            InitializeComponent();
            BindData();
            _dataGridIsFiltered = false;
        }

        /// <summary>
        /// Gets the list of all DVDs in the database, and uses it as source for the DataGrid.
        /// </summary>
        private void BindData()
        {
            if (_dataGridIsFiltered == false)
            {
                dataSource = new ObservableCollection<DVD>(BL_DVD.GetAll());
                dataSource.CollectionChanged += DataSourceChanged;
                grdDVDOverview.ItemsSource = dataSource;
                grdDVDOverview.DataContext = dataSource;
            }
            else
            {
                filteredSource = new ObservableCollection<DVD>(BL_DVD.Filter(_filterText, _filterCategory));
                filteredSource.CollectionChanged += DataSourceChanged;
                grdDVDOverview.ItemsSource = filteredSource;
                grdDVDOverview.DataContext = filteredSource;
            }
        }

        /// <summary>
        /// Determines what has to happen when the collection of DVD changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (DVD d in e.NewItems)
                        BL_DVD.Save(d);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (DVD d in e.OldItems)
                        BL_DVD.Delete(d);
                    break;
            }
        }

        /// <summary>
        /// Handles the editing of DVD's in the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDVDOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as DVD;

            lblError.Content = "";
            
            if(_changedValue.Stock >= _changedValue.ReservedAmount)
            {
                BL_DVD.Save(_changedValue);
            }
            else
            {
                _changedValue.Stock = _changedValue.ReservedAmount;
                lblError.Content = $"Stock ({_changedValue.Name}) cannot be lower than the current Reserved Amount.";
            }

            BindData();
        }
        
        /// <summary>
        /// Changes the visibility of the Details Row, to show the DVD description.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowDescription_Click(object sender, RoutedEventArgs e)
        {
            grdDVDOverview.RowDetailsVisibilityMode = 
                (grdDVDOverview.RowDetailsVisibilityMode == DataGridRowDetailsVisibilityMode.Collapsed) ? 
                DataGridRowDetailsVisibilityMode.VisibleWhenSelected : DataGridRowDetailsVisibilityMode.Collapsed;
        }

        /// <summary>
        /// Updates the DVD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            if (OnUpdateDVD != null)
                OnUpdateDVD(obj);
        }

        /// <summary>
        /// Deletes the DVD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            if (MessageBox.Show("Are you sure you want to delete this DVD?", "Delete DVD", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                dataSource.Remove(obj);
            }
        }

        #region DVD reservations and receiving DVDs

        /// <summary>
        /// Changes the available stock and reserved amount for a reservation to be made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            lblError.Content = "";

            if (obj.ReservedAmount <= obj.Stock - 1)
            {
                obj.ReservedAmount += 1;
                BL_DVD.Save(obj);
                BindData();
            }
            else
            {
                lblError.Content = $"No available DVD's ({obj.Name}) for new reservations.";
            }
        }

        /// <summary>
        /// Changes the available stock and reserved amount for when a DVD is received back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiveDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            lblError.Content = "";

            if (obj.ReservedAmount >= 1)
            {
                obj.ReservedAmount -= 1;
                BL_DVD.Save(obj);
                BindData();
            }
            else
            {
                lblError.Content = $"No reserved DVD's ({obj.Name}) left to receive.";
            }
        }

        #endregion

        #region Filtering DataGrid

        /// <summary>
        /// Filters the content of the datagrid, according to the filter category and chosen text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                _filterText = txtSearch.Text;
                _filterCategory = cmbxFilter.SelectedValue.ToString();

                _dataGridIsFiltered = true;

                BindData();
            }
            else
            {
                lblError.Content = "Please enter text to filter";
            }
            
        }

        /// <summary>
        /// Clears the filter selection and sets the content of the DataGrid back to its unfiltered content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetFilter_Click(object sender, RoutedEventArgs e)
        {
            _dataGridIsFiltered = false;
            _filterText = "";
            _filterCategory = "";

            cmbxFilter.SelectedIndex = 0;
            txtSearch.Text = "";
            BindData();
        }

        #endregion
    }
}
