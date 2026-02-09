namespace AnimalShelter.Api.DTO
{
    public class VolunteerUpdateDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        // Allow optional state update
        public string State { get; set; }
    }
}
