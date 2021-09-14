using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class SchoolsAround
    {
        [Key]
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public decimal? Miles { get; set; }

        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
