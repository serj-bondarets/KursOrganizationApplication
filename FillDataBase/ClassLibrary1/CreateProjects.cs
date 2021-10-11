using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DBWork
{
    public class CreateProjects
    {
        SqlConnection connection;

        Random random = new Random();

        public CreateProjects()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreateProjectsTable();
            connection.Close();
        }
 
        private void CreateProjectsTable()
        {
            
            List<string> depNames = DataBanks.departamentsNames;
            int[] projectsQuantity = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            for (int i = 0; i < 700; i++)
            {
                SqlCommand query = connection.CreateCommand();
                string commandText;
                var projectName = "";
                int selectedDepId = random.Next(10);
                projectName += "Проект ";
                projectName += RegexTreatnment(depNames[selectedDepId]);
                projectName += $" № {++projectsQuantity[selectedDepId]}";
                var date = CreateRandomDate();
                DataBanks.ProjectsStartDates.Add(i+1, date);
                commandText = "INSERT INTO Projects VALUES (@Name, @StartDate, @Description);";
                query.Parameters.AddWithValue("@Name", projectName); 
                query.Parameters.AddWithValue("@StartDate", date);
                query.Parameters.AddWithValue("@Description", DBNull.Value);
                query.CommandText = commandText;
                query.ExecuteNonQuery();
            }
        }

        private DateTime CreateRandomDate()
        {
            DateTime startDate = DataBanks.StartDate;
            int days = random.Next(1, (DateTime.Today - startDate).Days);
            DateTime date = startDate.AddDays(days);
            return date;
        }

        private string RegexTreatnment(string selectedDepartament)
        {
            Regex regex = new Regex(@"ский");
            string result = regex.Replace(selectedDepartament, "ского");
            regex = new Regex(@"отдел", RegexOptions.IgnoreCase);
            result = regex.Replace(result, "отдела");
            return result;
        }
    }
}
