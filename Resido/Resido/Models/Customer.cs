using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20), Required]
        public string Name { get; set; }


        [MaxLength(50), Required]
        public string Email { get; set; }

        [MaxLength(50), Required]
        public string Phone { get; set; }


        [MaxLength(220)]
        public string Password { get; set; }


        [NotMapped]
        public string ConfirmPass { get; set; }


        [ForeignKey("RegistrationOptionSelectId")]
        public int RegistrationOptionSelectId { get; set; }
        public RegistrationOptionSelect RegistrationOptionSelect { get; set; }


        public List<Review> Reviews { get; set; }

    }
}
