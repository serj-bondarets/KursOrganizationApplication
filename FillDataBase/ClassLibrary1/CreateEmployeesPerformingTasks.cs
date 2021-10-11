using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateEmployeesPerformingTasks
    {
        SqlConnection connection;

        Random random = new Random();

        public List<Task> tasks = DataBanks.tasks;

        public List<Employee> employees = DataBanks.employees;

        public CreateEmployeesPerformingTasks()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreatePerformingTable();
            connection.Close();
        }

        Dictionary<int, int> taskProfessions = new Dictionary<int, int>();

        private void CreatePerformingTable()
        {
            DefineDict();
            for (int i = 0; i < DataBanks.EmployeePerformingTasksQuantity; i++)
            {
                var task = tasks[random.Next(tasks.Count)];
                var employeesList = employees.Where(I => I.ProfessionId == taskProfessions[task.Id]).ToList();
                var employee = employeesList[random.Next(employeesList.Count)];
                Query(task.Id, employee.Id);
            }
        }

        private void DefineDict()
        {
            for (int i = 0; i < DataBanks.TasksQuantity; i++)
            {
                var task = tasks[i];
                var professionId = random.Next(1, DataBanks.ProfessionsQuantity + 1);
                taskProfessions.Add(task.Id, professionId);
            }

        }

        private void Query(int taskId, int employeeId)
        {
            SqlCommand query = connection.CreateCommand();
            string commandText;
            commandText = $"INSERT INTO EmployeesPerformingTasks VALUES ({taskId}, {employeeId});";
            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }

    }
}
