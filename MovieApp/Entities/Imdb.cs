namespace MovieApp.Entities
{
    public class Imdb
    {
        public int Id { get; set; }
        public double ImdbPoint { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
