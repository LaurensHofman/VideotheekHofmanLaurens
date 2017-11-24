using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VideotheekLibrary.Data;

namespace VideotheekHofmanLaurens
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        AppDbContext ctx = AppDbContext.Instance(System.Configuration.ConfigurationManager.ConnectionStrings["AppDbCS"].ConnectionString);
    }
}
