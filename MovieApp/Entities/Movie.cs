namespace MovieApp.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string imageUrl { get; set; }
        public int DirectorId { get; set; }
        public int ImdbId { get; set; }
        public Directors Directorss { get; set; }
        public Imdb Imdbs { get; set; }
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; }

    }
}
