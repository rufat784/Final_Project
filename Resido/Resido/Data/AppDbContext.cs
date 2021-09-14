using Microsoft.EntityFrameworkCore;
using Resido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resido.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Aboutcs> Aboutcs { get; set; }
        public DbSet<AmenetiesProperty> AmenetiesProperties { get; set; }
        public DbSet<BathroomCount> BathroomCounts { get; set; }
        public DbSet<BedroomsCount> BedroomsCounts { get; set; }
        public DbSet<RoomsCount> RoomsCounts { get; set; }
        public DbSet<HowItWorks> HowItWorks { get; set; }


        public DbSet<PropertyVideo> PropertyVideos { get; set; }

        public DbSet<BuildingAge> BuildingAges { get; set; }
        public DbSet<CityOfProperty> CityOfProperties { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAdress> ContactAdresses { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<FloorPlanToProperty> FloorPlanToProperties { get; set; }
        public DbSet<FoodsAround> FoodsArounds { get; set; }

        public DbSet<GarageCount> GarageCounts { get; set; }
        public DbSet<MyProfileForAgents> MyProfileForAgents { get; set; }
        public DbSet<OtherFeatures> OtherFeatures { get; set; }
        public DbSet<OurMissionInAbout> OurMissionInAbouts { get; set; }
        public DbSet<OurMissionMainImage> OurMissionMainImages { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImages> PropertyImages { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<RegistrationOptionSelect> RegistrationOptionSelects { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SchoolsAround> SchoolsArounds { get; set; }
        public DbSet<SiteSocials> SiteSocials { get; set; }
        public DbSet<SocialsMyProfile> SocialsMyProfiles { get; set; }
        public DbSet<SocialsToOurTeam> SocialsToOurTeams { get; set; }
        public DbSet<SocialToMyProf> SocialToMyProfs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Subscribed> Subscribeds { get; set; }

        public DbSet<TeamsSocial> TeamsSocials { get; set; }
        public DbSet<UserAdmin> UserAdmins { get; set; }


    }
}
