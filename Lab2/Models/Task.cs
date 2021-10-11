using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Task
    {
        public Task()
        {
            EmployeesPerformingTasks = new HashSet<EmployeesPerformingTask>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool CompletionMark { get; set; }
        public DateTime ControlDate { get; set; }
        public string FailureReason { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<EmployeesPerformingTask> EmployeesPerformingTasks { get; set; }
    }
}
