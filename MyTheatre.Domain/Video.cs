namespace MyTheatre.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }

        public int? GenreId { get; set;}
        public virtual Genre Genre { get;set;}
    }
}