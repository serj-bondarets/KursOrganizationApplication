using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public class Task
    {
        public int Id;

        public int ProjectId;

        public DateTime StartDate;

        public DateTime Deadline;

        public int CompletionMark;

        public DateTime ControlDate;

        public string FailureReason;

    }
}
