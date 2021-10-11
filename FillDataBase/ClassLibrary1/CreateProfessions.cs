using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateProfessions
    {

        SqlConnection connection;

        public CreateProfessions()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreateProfessionsTable();
            connection.Close();
        }

        Dictionary<string, int> qualificationsBank = DataBanks.qualificationsBank;

        private void CreateProfessionsTable()
        {
            SqlCommand query = connection.CreateCommand();
            string commandText = "";
            
            for (var i = 0; i < DataBanks.ProfessionsQuantity; i++)
            {
                var pair = qualificationsBank.ElementAt(i);
                commandText += $"INSERT INTO Professions VALUES ({i+1},'{pair.Key}', {pair.Value});";
            }
            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }
    }
}
