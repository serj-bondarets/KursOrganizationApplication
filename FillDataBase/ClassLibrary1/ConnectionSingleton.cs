using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    
    /// <summary>
    /// Provides an connection to database
    /// </summary>
    
    class ConnectionSingleton
    {
        /// <summary>
        /// Instance
        /// </summary>

        private static readonly Lazy<ConnectionSingleton> instance = new Lazy<ConnectionSingleton>(() => new ConnectionSingleton());

        /// <summary>
        /// Connection
        /// </summary>

        private readonly SqlConnection connection = new SqlConnection("Data Source=RAZVALINA\\SQLEXPRESS;Initial Catalog=Organization;Integrated Security=True");

        /// <summary>
        /// Gets instance
        /// </summary>

        public static ConnectionSingleton Instance
        {
            get
            {
                return instance.Value;
            }
        }



        /// <summary>
        /// Gets connection
        /// </summary>
        /// <returns>Connection</returns>

        public SqlConnection GetDBConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            return connection;
        }

    }
}
