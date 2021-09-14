using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class SocialsToOurTeam
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OurTeamId")]
        public int OurTeamId { get; set; }
        public OurTeam OurTeam { get; set; }


        public string Link { get; set; }



        [ForeignKey("TeamsSocialId")]
        public int TeamsSocialId { get; set; }
        public TeamsSocial TeamsSocial { get; set; }
    }
}
