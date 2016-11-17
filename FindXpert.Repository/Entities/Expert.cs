using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;

namespace FindXpert.Repository.Entities
{
    [Table("Experts")]
    public class Expert
    {
        public int      Id { get; set; }

        [Required]
        [StringLength(100)]
        public string   FirstName { get; set; }
        public string   LastName { get; set; }

        public virtual ICollection<Project>  Projects{ get; set; }
    }
}
