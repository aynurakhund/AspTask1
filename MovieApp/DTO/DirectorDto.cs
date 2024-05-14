using System.ComponentModel.DataAnnotations;

namespace MovieApp.DTO
{
    public class DirectorDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
