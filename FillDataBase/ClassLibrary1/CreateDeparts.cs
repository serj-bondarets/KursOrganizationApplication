using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateDeparts
    {
        SqlConnection connection;
        public CreateDeparts()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreateDepartsTable();
            connection.Close();
        }

        private void CreateDepartsTable()
        {
            SqlCommand query = connection.CreateCommand();
            List<string> depNames = DataBanks.departamentsNames;
            List<string> depPhones = DataBanks.depPhones;
            string commandText = "";
            for (int i = 0; i < depNames.Count; i++)
            {
                commandText += $"INSERT INTO Departaments VALUES ('{depNames[i]}','{depPhones[i]}');";
            }
            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }
    }
}
