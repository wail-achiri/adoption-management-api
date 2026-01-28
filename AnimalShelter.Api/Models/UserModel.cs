using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRol Rol { get; set; }
        public UserState State { get; set; }


        public ICollection<AdoptionModel> VolunteerAdoptions { get; set; }
        public ICollection<AdoptionModel> AdopterAdoptions { get; set; }
    }
}
