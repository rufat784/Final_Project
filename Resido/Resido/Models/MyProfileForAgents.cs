using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Models
{
    public class MyProfileForAgents
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime AddedDAte { get; set; }


        public string ProfileImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required, MaxLength(100)]
        public string OwnerName { get; set; }

        [MaxLength(220)]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPass { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string YourPosition { get; set; }



        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Adress { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(20)]
        public string ZipCode { get; set; }

        [MaxLength(300)]
        public string About { get; set; }

        public List<SocialToMyProf> SocialToMyProfs { get; set; }

        public List<Review> Reviews { get; set; }

        public bool IsAgency { get; set; }
        public string CompanySize { get; set; }
        public string CompanyStatus { get; set; }



        [ForeignKey("RegistrationOptionSelectId")]
        public int RegistrationOptionSelectId { get; set; }
        public RegistrationOptionSelect RegistrationOptionSelect { get; set; }

        public List<Property> Properties { get; set; }
        public List<Subscribed> Subscribeds { get; set; }


    }
}
