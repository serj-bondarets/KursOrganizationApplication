using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateEmployees
    {
        SqlConnection connection;

        public CreateEmployees()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreateEmployeesTable();
            connection.Close();
        }

        private void CreateEmployeesTable()
        {
            
            for (int i = 0; i < DataBanks.EmployeesQuantity; i++)
            {
                Employee employee = new Employee();
                employee.Id = i + 1;
                employee.Sex = DefineSex();
                DefineName(employee);
                employee.Busy = DefineBusy();
                DefineSupposedDate(employee);
                employee.ProfessionId = DefineProfession();
                Query(employee);
                DataBanks.employees.Add(employee);
            } 
        }
        Random random = new Random();

        private void Query(Employee employee)
        {
            SqlCommand query = connection.CreateCommand();
            string commandText;
            commandText = "INSERT INTO Employees VALUES (@ProfessionId, @SurName, @Name, @FatherName, @Sex, @Busy, @Date);";
            query.Parameters.AddWithValue("@ProfessionId", employee.ProfessionId);
            query.Parameters.AddWithValue("@SurName", employee.SurName);
            query.Parameters.AddWithValue("@Name", employee.Name);
            query.Parameters.AddWithValue("@FatherName", employee.FatherName);
            query.Parameters.AddWithValue("@Sex", employee.Sex);
            query.Parameters.AddWithValue("@Busy", employee.Busy);
            if (employee.SupposedFinishLastTaskDate != null)
                query.Parameters.AddWithValue("@Date", employee.SupposedFinishLastTaskDate);
            else
                query.Parameters.AddWithValue("@Date", DBNull.Value);
            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }

        private string DefineSex()
        {
            int number = random.Next(0, 10);
            string result = (number < 8) ? "Мужской": "Женский";
            return result;
        }

        private void DefineName(Employee employee)
        {
            List<string> namesManBank = DataBanks.namesManBank;
            List<string> surNamesManBank = DataBanks.surNamesManBank;
            List<string> fatherNamesManBank = DataBanks.fatherNamesManBank;
            List<string> namesWomanBank = DataBanks.namesWomanBank;
            List<string> surNamesWonamBank = DataBanks.surNamesWonamBank;
            List<string> fatherNamesWomanBank = DataBanks.fatherNamesWomanBank;
            if (employee.Sex == "Мужской")
            {
                employee.Name = namesManBank[random.Next(namesManBank.Count - 1)];
                employee.SurName = surNamesManBank[random.Next(surNamesManBank.Count - 1)];
                employee.FatherName = fatherNamesManBank[random.Next(fatherNamesManBank.Count - 1)];
            }
            else
            {
                employee.Name = namesWomanBank[random.Next(namesWomanBank.Count - 1)];
                employee.SurName = surNamesWonamBank[random.Next(surNamesWonamBank.Count - 1)];
                employee.FatherName = fatherNamesWomanBank[random.Next(fatherNamesWomanBank.Count - 1)];
            }
        }

        private int DefineBusy()
        {
            int number = random.Next(0, 100);
            int result = (number < 90) ? 1 : 0;
            return result;
        }

        private void DefineSupposedDate(Employee employee)
        {
            int randomId = random.Next(1, DataBanks.TasksQuantity + 1);
            DateTime deadline = DataBanks.tasks.Where(i=>i.Id == randomId).Select(i => i.Deadline).FirstOrDefault();
            if (employee.Busy == 1)
            {
                employee.SupposedFinishLastTaskDate = deadline.AddDays(random.Next(3)*Math.Pow(-1, random.Next(1, 11)));
            }
            else
            {
                employee.SupposedFinishLastTaskDate = null;
            }    

        }

        private int DefineProfession()
        {
            var selectedProfessionId = random.Next(1, DataBanks.ProfessionsQuantity+1);
            return selectedProfessionId;
        }
    }
}
