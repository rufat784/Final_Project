using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class FloorPlan
    {
        [Key]
        public int Id { get; set; }
        public string FloorNumber { get; set; }
        public string SquareKv { get; set; }
        public List<FloorPlanToProperty> FloorPlanToProperties { get; set; }

    }
}
