using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmReset
    {
        [MaxLength(55), Required]
        public string Password { get; set; }

        [MaxLength(55), Required]
        public string ConfirmPass { get; set; }
    }
}
