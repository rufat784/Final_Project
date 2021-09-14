using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("ReviewId")]
        public int? ReviewId { get; set; }
        public Review ParentReview { get; set; }


        [ForeignKey("MyProfileForAgentsId")]
        public int MyProfileForAgentsId { get; set; }
        public MyProfileForAgents MyProfileForAgents { get; set; }


        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }



        public string Content { get; set; }
        public byte Rating { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
