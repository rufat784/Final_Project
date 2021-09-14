using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmHome
    {
        public List<HowItWorks> HowItWorks { get; set; }
        public List<Property> Properties { get; set; }
        public List<CityOfProperty> CityOfProperties { get; set; }
        public List<Review> Reviews { get; set; }

        public Property Property { get; set; }

        public List<PropertyType> PropertyTypes { get; set; }
        public List<PropertyStatus> PropertyStatuses { get; set; }
        public List<BedroomsCount> BedroomsCounts { get; set; }
        public List<BathroomCount> BathroomCounts { get; set; }
        public List<BuildingAge> BuildingAges { get; set; }
        public List<GarageCount> Garages { get; set; }


    }
}
