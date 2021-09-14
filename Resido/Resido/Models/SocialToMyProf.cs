using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class SocialToMyProf
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MyProfileForAgentsId")]
        public int MyProfileForAgentsId { get; set; }
        public MyProfileForAgents MyProfileForAgents { get; set; }


        public string Link { get; set; }



        [ForeignKey("SocialsMyProfileId")]
        public int SocialsMyProfileId { get; set; }
        public SocialsMyProfile SocialsMyProfile { get; set; }
    }
}
