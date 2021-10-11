using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public class CreateTasks
    {
        SqlConnection connection;

        Random random = new Random();

        Task task;

        public CreateTasks()
        {
            connection = ConnectionSingleton.Instance.GetDBConnection();
            CreateTasksTable();
            connection.Close();
        }

        private void CreateTasksTable() 
        {
            for (int i = 0; i < DataBanks.TasksQuantity; i++)
            {
                task = new Task();
                task.Id = i + 1;
                task.ProjectId = DefineProjectId();
                DefineDates();
                DefineCompletionMark();
                DefineFailureReason();
                Query();
                DataBanks.tasks.Add(task);
            }
        }

        private void Query()
        {
            SqlCommand query = connection.CreateCommand();
            string commandText;
            commandText = "INSERT INTO Tasks VALUES (@ProjectId, @StartDate, @Deadline, @CompletionMark, @ControlDate, @FailureReason);";
            query.Parameters.AddWithValue("@ProjectId", task.ProjectId);
            query.Parameters.AddWithValue("@StartDate", task.StartDate);
            query.Parameters.AddWithValue("@Deadline", task.Deadline);
            query.Parameters.AddWithValue("@CompletionMark", task.CompletionMark);
            query.Parameters.AddWithValue("@ControlDate", task.ControlDate);
            if (task.FailureReason != null)
                query.Parameters.AddWithValue("@FailureReason", task.FailureReason);
            else
                query.Parameters.AddWithValue("@FailureReason", DBNull.Value);
            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }

        private void DefineCompletionMark()
        {
            int mark = (random.Next(100) < 95) ? 1 : 0;  
            task.CompletionMark = mark;
        }

        private int DefineProjectId()
        {
            return random.Next(1, DataBanks.ProjectsQuantity+1);
        }

        private void DefineDates()
        {
            task.StartDate = DataBanks.ProjectsStartDates[task.ProjectId];
            int daysDeadline = random.Next(7, 14);
            task.Deadline = task.StartDate.AddDays(daysDeadline);
            task.ControlDate = task.Deadline.AddDays(random.Next(4)*Math.Pow(-1, random.Next(10)));
        }

        List<string> failureReasons = DataBanks.failureReasons;

        private void DefineFailureReason()
        {
            if(task.CompletionMark == 0)
                task.FailureReason = failureReasons[random.Next(failureReasons.Count)];
            else
                task.FailureReason = null;
        }
        
    }
}
