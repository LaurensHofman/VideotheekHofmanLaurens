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
        public delegate void UpdateDVD(DVD model);
        public event UpdateDVD OnUpdateDVD;

        private readonly AppDbContext context;
        
        public ObservableCollection<DVD> dataSource { get; set; }

        public DVDOverview()
        {
            InitializeComponent();
            context = AppDbContext.Instance();
            BindData();
        }

        private void BindData()
        {
            dataSource = new ObservableCollection<DVD>(BL_DVD.GetAll());
            dataSource.CollectionChanged += DataSourceChanged;
            grdDVDOverview.ItemsSource = dataSource;
            grdDVDOverview.DataContext = dataSource;
        }

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

        private void btnUpdateDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            if (OnUpdateDVD != null)
                OnUpdateDVD(obj);
        }

        private void btnDeleteDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            if (MessageBox.Show("Are you sure you want to delete this DVD?", "Delete DVD", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                dataSource.Remove(obj);
            }
        }

        private void grdDVDOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as DVD;

            lblStockError.Content = "";
            
            if(_changedValue.Stock >= _changedValue.ReservedAmount)
            {
                BL_DVD.Save(_changedValue);
                BindData();
            }
            else
            {
                var test = BL_DVD.GetOldStock(_changedValue.ID);
                MessageBox.Show(test.ToString());
                lblStockError.Content = $"Stock from ({_changedValue.Name}) cannot be lower than the current Reserved Amount.";
            }
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;

            lblStockError.Content = "";

            if(obj.ReservedAmount <= obj.Stock - 1)
            {
                obj.ReservedAmount += 1;
                BL_DVD.Save(obj);
                BindData();
            }
            else
            {
                lblStockError.Content = $"No available DVD's ({obj.Name}) for new reservations.";
            }
        }

        private void btnShowDescription_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
