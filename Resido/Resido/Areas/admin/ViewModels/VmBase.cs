using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Areas.admin.ViewModels
{
    public class VmBase
    {
        public List<Property> Properties { get; set; }
        public List<PropertyStatus> Statuses { get; set; }
        public List<PropertyType> Types { get; set; }
        public List<MyProfileForAgents> LatestUsers { get; set; }
        public List<MyProfileForAgents> LatestCustomers { get; set; }



        public List<CityOfProperty> City { get; set; }
        public List<BathroomCount> BathroomCounts { get; set; }
        public List<BedroomsCount> BedroomsCounts { get; set; }
        public List<RoomsCount> RoomsCounts { get; set; }

        public List<BuildingAge> BuildingAges { get; set; }
        public List<GarageCount> GarageCounts { get; set; }
        public List<HowItWorks> HowItWorks { get; set; }
        public Aboutcs About { get; set; }
        public List<Aboutcs> Abouts { get; set; }
        public List<MyProfileForAgents> MyProfileForAgents { get; set; }
        public List<OurMissionInAbout> OurMissions { get; set; }
        public List<OurMissionMainImage> OurMissionMainImages { get; set; }






        public List<Contact> Contacts { get; set; }
        public List<ContactPhone> ContactPhones { get; set; }


        public ContactPhone Phone { get; set; }



        public CityOfProperty Name { get; set; }
        public CityOfProperty Image { get; set; }
        public IFormFile ImageFile { get; set; }



        public BathroomCount CountName { get; set; }
        public BuildingAge Years { get; set; }

        public PropertyType Type { get; set; }


        public HowItWorks Icon { get; set; }
        public HowItWorks Title { get; set; }
        public HowItWorks Desc { get; set; }

        public OurMissionInAbout OurMissionInAbout { get; set; }
        public OurMissionMainImage OurMissionMainImage { get; set; }









    }
}
