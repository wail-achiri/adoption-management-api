namespace AnimalShelter.Api.DTO
{
    public class VolunteerCreateDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Optional initial state (e.g., "ACTIVE", "INACTIVE"); if omitted, service will use default
        public string State { get; set; }
    }
}
