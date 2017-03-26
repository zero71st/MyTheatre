using System.Collections.Generic;

namespace MyTheatreApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set;}

        public virtual IEnumerable<Video> Videos { get; set; }
    }
}