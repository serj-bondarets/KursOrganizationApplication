using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Departament
    {
        public Departament()
        {
            Professions = new HashSet<Profession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Profession> Professions { get; set; }
    }
}
