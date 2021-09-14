using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class RegistrationOptionSelect
    {
        [Key]
        public int Id { get; set; }
        public string OptionSelect { get; set; }

        public List<MyProfileForAgents> MyProfileForAgents { get; set; }
        public List<Customer> Customers { get; set; }



    }
}
