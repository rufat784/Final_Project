using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class ContactPhone
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }



        [Required(ErrorMessage = "Required Field"), Phone]
        [RegularExpression("^\\+[0-9]{3}\\s\\((\\d+)\\)-\\d{3}-\\d{2}-\\d{2}", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
    }
}
