using Microsoft.AspNetCore.Http;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmSignUp
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(220), Required]
        public string FullName { get; set; }

        [MaxLength(220), Required]
        public string Email { get; set; }

        [MaxLength(220), Required]
        public string Phone { get; set; }


        public List<RegistrationOptionSelect> RegistrationOptionSelects { get; set; }


        [ForeignKey("RegistrationOptionSelectId")]
        public int RegistrationOptionSelectId { get; set; }
        public RegistrationOptionSelect RegistrationOptionSelect { get; set; }


        [MaxLength(220), Required]
        public string Password { get; set; }

        [MaxLength(220), Required]
        public string ConfirmPass { get; set; }


        public MyProfileForAgents MyProfileForAgents { get; set; }
        public Customer Customer { get; set; }




        public string ProfileImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(100)]
        public string OwnerName { get; set; }


        [MaxLength(50)]
        public string State { get; set; }


        [MaxLength(100)]
        public string YourPosition { get; set; }


        [MaxLength(150)]
        public string Adress { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(20)]
        public string ZipCode { get; set; }

        [MaxLength(300)]
        public string About { get; set; }

        public List<SocialToMyProf> SocialToMyProfs { get; set; }

        public bool IsAgency { get; set; }
        public string CompanySize { get; set; }
        public string CompanyStatus { get; set; }
    }
}
