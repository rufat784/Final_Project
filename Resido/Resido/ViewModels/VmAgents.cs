using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmAgents
    {
        public List<MyProfileForAgents> Agents { get; set; }
        public List<Subscribed> Subscribeds { get; set; }
        public Property Property { get; set; }

        public List<Property> Properties_rent { get; set; }
        public List<Property> Properties_monthrent { get; set; }


        public List<Property> Properties_sale { get; set; }

        public List<Property> LatestProps { get; set; }



        public Subscribe Subscribe { get; set; }



        public Subscribed Subscribed { get; set; }

        public MyProfileForAgents SingleAgent { get; set; }


    }
}
