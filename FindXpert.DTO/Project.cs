using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindXpert.DTO
{
    public class Project
    {
        public int      Id { get; set; }

        public int      ExpertId { get; set; }

        public string   Decription { get; set; }
        public DateTime Date { get; set; }
    }
}
