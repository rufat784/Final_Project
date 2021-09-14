using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmAllProperties
    {
        public List<Property> Properties { get; set; }
        public List<Property> Featured { get; set; }

        public List<OtherFeatures> OtherFeatures { get; set; }

        public List<PropertyImages> PropertyImages { get; set; }

        public List<CityOfProperty> CityOfProperties { get; set; }
        public List<PropertyType> PropertyTypes { get; set; }
        public List<PropertyStatus> PropertyStatuses { get; set; }
        public List<BedroomsCount> BedroomsCounts { get; set; }
        public List<BathroomCount> BathroomCounts { get; set; }
        public List<BuildingAge> BuildingAges { get; set; }
        public List<GarageCount> Garages { get; set; }

        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }


        public List<Review> Reviews { get; set; }

        public Property Property { get; set; }


        public int? cityId { get; set; }
        public int typeId { get; set; }
        public int statusId { get; set; }
        public int bedId { get; set; }
        public int? bathId { get; set; }
        public int? ageId { get; set; }
        public int? garageId { get; set; }
        public string searchByPrice { get; set; }

        public VmAllProperties Filter { get; set; }









    }
}
