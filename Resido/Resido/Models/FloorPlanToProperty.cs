using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class FloorPlanToProperty
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }


        [ForeignKey("FloorPlanId")]
        public int FloorPlanId { get; set; }
        public FloorPlan FloorPlan { get; set; }
    }
}
