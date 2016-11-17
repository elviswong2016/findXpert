using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindXpert.Repository.Entities
{
    [Table("Projects")]
    public class Project
    {
        public int Id { get; set; }

        public int ExpertId { get; set; }

        [Required]
        [StringLength(500)]
        public string Decription { get; set; }
        public DateTime Date { get; set; }
    }
}
