namespace MovieApp.Entities
{
    public class Subtitle
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; }
    }
}
