using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        public Reservation ResModel { get; set; }
        public ObservableCollection<Client> collClient { get; set; }
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

            collClient = new ObservableCollection<Client>(BL_Client.GetAll());
            cmbxClientSelect.ItemsSource = collClient;
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

            BL_DVD.Save(_changedValue);
        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as DVD;
            ResModel = new Reservation();

            ResModel.ResDVDID = obj.ID;
            ResModel.DVDDetails = BL_DVD.GetDetails(ResModel.ResDVDID);

            ResModel.ResClientID = int.Parse(cmbxClientSelect.SelectedValue.ToString());
            ResModel.ClientFullDetails = BL_Client.GetFullDetails(ResModel.ResClientID);

            BL_Reservation.Create(ResModel);
        }
    }
}
