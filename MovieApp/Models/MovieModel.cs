namespace MovieApp.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ImgUrl { get; set; }
        public double ImdbPoint { get; set; }
        public string Director { get; set; }
        public int DirectorId { get; set; }
        public int ImdbId { get; set; }
    }
}
