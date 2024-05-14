using System.ComponentModel.DataAnnotations;

namespace MovieApp.DTO
{
    public class MovieDto
    {
        [Required]
        public string movieName { get; set; }
        [Required]
        public string imgUrl { get; set; }
        [Required]
        public string DirectorId { get; set; }
        [Required]
        public string ImdbId { get; set; }
    }
}
