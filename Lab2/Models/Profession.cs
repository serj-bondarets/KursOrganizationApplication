using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Profession
    {
        public Profession()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int DepartamentId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public virtual Departament Departament { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
