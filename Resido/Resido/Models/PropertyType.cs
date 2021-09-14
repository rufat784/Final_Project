using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }
}
