﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class Aboutcs
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
