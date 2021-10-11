using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class ClearDataBase
    {
        SqlConnection connection;

        List<string> allTables = DataBanks.allTables;
        public ClearDataBase()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            ClearAllTables();
            connection.Close();
        }

        private void ClearAllTables()
        {
            SqlCommand query = connection.CreateCommand();
            foreach (var tableForDelete in allTables)
            {
                query.CommandText = $"DELETE FROM {tableForDelete} DBCC CHECKIDENT ('{tableForDelete}', RESEED, 0)";
                query.ExecuteNonQuery();
            }
        }
    }
    
}
