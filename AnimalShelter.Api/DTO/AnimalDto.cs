using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Models
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Breed { get; set; }
        public string Type { get; set; }
        public string State { get; set; }

    }

}
