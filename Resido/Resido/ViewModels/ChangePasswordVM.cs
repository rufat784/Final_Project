using Resido.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]

        public string NewPassword { get; set; }
        [Required]

        public string ConfirmPassword { get; set; }

        public MyProfileForAgents SingleAgent { get; set; }

    }
}
