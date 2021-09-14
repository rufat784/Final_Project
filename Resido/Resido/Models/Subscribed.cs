﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class Subscribed
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public DateTime AddedDate { get; set; }


        [ForeignKey("MyProfileForAgentsId")]
        public int MyProfileForAgentsId { get; set; }
        public MyProfileForAgents MyProfileForAgents { get; set; }

    }
}
