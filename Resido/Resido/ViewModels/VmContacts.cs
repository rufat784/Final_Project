using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmContacts
    {
        public  Contact Contact { get; set; }
        public List<ContactPhone> ContactPhones { get; set; }
        public List<ContactAdress> ContactAdresses { get; set; }
        public List<ContactEmail> ContactEmails { get; set; }
    }
}
