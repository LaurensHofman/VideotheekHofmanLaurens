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
    /// Interaction logic for ReservationOverview.xaml
    /// </summary>
    public partial class ReservationOverview : UserControl
    {
        private readonly AppDbContext context;

        public ReservationOverview()
        {
            InitializeComponent();
            context = AppDbContext.Instance();
            BindData();
        }

        private ObservableCollection<Client> collClient { get; set; }
        private ObservableCollection<Reservation> dataSource { get; set; }

        private void BindData()
        {
            dataSource = new ObservableCollection<Reservation>(BL_Reservation.GetAll());
            dataSource.CollectionChanged += DataSourceChanged;
            grdReservationOverview.ItemsSource = dataSource;
            grdReservationOverview.DataContext = dataSource;

            collClient = new ObservableCollection<Client>(BL_Client.GetAll());
            cmbxClientSelect.ItemsSource = collClient;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    foreach (Reservation r in e.OldItems)
                        BL_Reservation.Delete(r);
                    break;
            }
        }

        private void btnReceiveDVD_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Reservation;
            
            dataSource.Remove(obj);
        }

        private void cmbxClientSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int resClientID = int.Parse(cmbxClientSelect.SelectedValue.ToString());

            dataSource = new ObservableCollection<Reservation>(BL_Reservation.GetSpecific(resClientID));
            grdReservationOverview.ItemsSource = dataSource;
            grdReservationOverview.DataContext = dataSource;
        }
    }
}
