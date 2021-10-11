using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class EmployeesPerformingTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
