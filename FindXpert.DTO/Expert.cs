using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindXpert.DTO
{
    public class Expert
    {
        public int      Id { get; set; }
        public string   FirstName { get; set; }
        public string   LastName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
