using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.Data
{
    /// <summary>
    /// Contains the data and actions required to connect with the database.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets/sets the database set for DVDs.
        /// </summary>
        public DbSet<DVD> DVDs { get; set; }

        public AppDbContext() : base(@"Data Source=DESKTOP-QJLP9GV\LAURENSSQL;Initial Catalog=VideotheekHofmanLaurens;Persist Security Info=True;User ID=VideotheekHofmanLaurens;Password=hofmanlaurens")
        {

        }

        public AppDbContext(string connectionString) : base(connectionString)
        {

        }

        private static AppDbContext _instance;

        public static AppDbContext Instance(string connectionString = null)
        {
            if (_instance == null)
            {
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    _instance = new AppDbContext(connectionString);
                }
            }

            return _instance;
        }
    }
}
