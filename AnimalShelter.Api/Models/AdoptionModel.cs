using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Models
{
    public class AdoptionModel
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public AnimalModel Animal { get; set; }

        public int VolunteerId { get; set; }
        public UserModel Volunteer { get; set; }

        public int AdopterId { get; set; }
        public UserModel Adopter { get; set; }

        public DateOnly AdoptionDate { get; set; }
        public AdoptionState State { get; set; }



    }
}
