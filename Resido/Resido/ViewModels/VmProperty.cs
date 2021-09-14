using Microsoft.AspNetCore.Http;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.ViewModels
{
    public class VmProperty
    {
        public List<Property> Properties { get; set; }

        public Property Property { get; set; }

        public List<PropertyStatus> PropertyStatuses { get; set; }



        public int Id { get; set; }

        [ForeignKey("MyProfileForAgentsId")]
        public int MyProfileForAgentsId { get; set; }
        public MyProfileForAgents MyProfileForAgents { get; set; }


        public string MainImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public IFormFile[] PropertyImages { get; set; }

        public string Name { get; set; }
        public string AreaKv { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime AddedDate { get; set; }
        public List<FloorPlanToProperty> FloorPlanToProperties { get; set; }


        [ForeignKey("CityOfPropertyId")]
        public int CityOfPropertyId { get; set; }
        public CityOfProperty CityOfProperty { get; set; }



        [ForeignKey("PropertyStatusId")]
        public int PropertyStatusId { get; set; }
        public PropertyStatus PropertyStatus { get; set; }


        [ForeignKey("PropertyTypeId")]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }


        [ForeignKey("BathroomCountId")]
        public int BathroomCountId { get; set; }
        public BathroomCount BathroomCount { get; set; }


        [ForeignKey("BedroomsCountId")]
        public int BedroomsCountId { get; set; }
        public BedroomsCount BedroomsCount { get; set; }


        [ForeignKey("GarageCountId")]
        public int GarageCountId { get; set; }
        public GarageCount GarageCount { get; set; }

        [ForeignKey("RoomsCountId")]
        public int RoomsCountId { get; set; }
        public RoomsCount RoomsCount { get; set; }

        [ForeignKey("BuildingAgeId")]
        public int BuildingAgeId { get; set; }
        public BuildingAge BuildingAge { get; set; }


        public List<OtherFeatures> OtherFeatures { get; set; }
        public OtherFeatures OtherFeature { get; set; }

        public List<AmenetiesProperty> AmenetiesProperties { get; set; }

        public List<Review> Reviews { get; set; }


    }
}
