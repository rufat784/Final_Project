using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class SocialsMyProfile
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }

        public List<SocialToMyProf> SocialToMyProfs { get; set; }

    }
}
