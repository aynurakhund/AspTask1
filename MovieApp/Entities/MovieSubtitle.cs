namespace MovieApp.Entities
{
    public class MovieSubtitle
    {
        public int MovieId { get; set; }
        public int SubtitleId { get; set; }
        public Movie Movies { get; set; }
        public Subtitle Subtitles { get; set; }
    }
}
