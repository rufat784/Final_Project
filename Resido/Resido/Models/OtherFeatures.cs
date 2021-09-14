using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class OtherFeatures
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string Desc { get; set; }


        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
