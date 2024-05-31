namespace SuperHeroAPI.DTOs
{
    public class UpdateSuperHeroDTO
    {
        public required string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Place { get; set; }
    }
}
