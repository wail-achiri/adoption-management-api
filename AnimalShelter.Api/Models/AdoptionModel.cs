using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Models
{
    public class AdoptionModel
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int VolunteerId { get; set; }
        public int AdopterId { get; set; }
        public DateOnly AdoptionDate { get; set; }
        public AdoptionState State { get; set; }



    }
}
