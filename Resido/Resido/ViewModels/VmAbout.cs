using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmAbout
    {
        public Aboutcs Aboutcs { get; set; }
        public OurMissionMainImage OurMissionMainImage { get; set; }

        public List<MyProfileForAgents>OurAgents { get; set; }
        public List<OurMissionInAbout> OurMission { get; set; }


    }
}
