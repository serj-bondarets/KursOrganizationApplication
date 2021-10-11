using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateAllTables
    {
        SqlConnection connection;

        public CreateAllTables()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            Create();
            connection.Close();
        }

        public void Create()
        {
            CreateDeparts createDeparts = new CreateDeparts();
            CreateProjects createProjects = new CreateProjects();
            CreateProfessions createProfessions = new CreateProfessions();
            CreateTasks createTasks = new CreateTasks();
            CreateEmployees createEmployees = new CreateEmployees();
            CreateEmployeesPerformingTasks createEmployeesPerforming = new CreateEmployeesPerformingTasks();
        }
    }
}
