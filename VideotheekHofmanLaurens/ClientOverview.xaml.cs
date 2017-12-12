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
    /// Interaction logic for ClientOverview.xaml
    /// </summary>
    public partial class ClientOverview : UserControl
    {
        public delegate void UpdateClient(Client model);
        public event UpdateClient OnUpdateClient;

        private readonly AppDbContext context;

        public ClientOverview()
        {
            InitializeComponent();
            context = AppDbContext.Instance();
            BindData();
        }

        private ObservableCollection<Client> dataSource { get; set; }

        private void BindData()
        {
            dataSource = new ObservableCollection<Client>(BL_Client.GetAll());
            dataSource.CollectionChanged += DataSourceChanged;
            grdClientOverview.ItemsSource = dataSource;
            grdClientOverview.DataContext = dataSource;
        }

        private void DataSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Client c in e.NewItems)
                        BL_Client.Save(c);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (Client c in e.OldItems)
                        BL_Client.Delete(c);
                    break;
            }
        }

        private void rbtnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Client;

            if (OnUpdateClient != null)
                OnUpdateClient(obj);
        }

        private void rbtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var obj = ((FrameworkElement)sender).DataContext as Client;

            if (MessageBox.Show("Are you sure you want to delete this client?", "Delete client", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                dataSource.Remove(obj);
            }
        }

        private void grdClientOverview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridRow _dgRow = e.Row;
            var _changedValue = _dgRow.DataContext as Client;

            BL_Client.Save(_changedValue);
        }
    }
}
