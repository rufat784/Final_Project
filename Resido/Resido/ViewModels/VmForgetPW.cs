using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmForgetPW
    {
        [MaxLength(50), Required]
        public string Email { get; set; }
    }
}
