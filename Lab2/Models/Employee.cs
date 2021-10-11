using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeesPerformingTasks = new HashSet<EmployeesPerformingTask>();
        }

        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Sex { get; set; }
        public bool Busy { get; set; }
        public DateTime? SupposedFinishCurrentTaskDate { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual ICollection<EmployeesPerformingTask> EmployeesPerformingTasks { get; set; }
    }
}
