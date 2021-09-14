using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmLogin
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(220), Required]
        public string Email { get; set; }


        [MaxLength(220), Required]
        public string Password { get; set; }


        public int? isCommentPrdId { get; set; }

    }
}
