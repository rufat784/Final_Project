using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class SiteSocials
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
