using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public AnimalType Type { get; set; }
        public AnimalState State { get; set; }
    }

}
