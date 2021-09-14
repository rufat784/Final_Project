using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Areas.admin.ViewModels
{
    public class VmOM:VmBase
    {
        public List<OurMissionInAbout> OurMissions { get; set; }
        public OurMissionInAbout OurMissionInAbout { get; set; }

    }
}
