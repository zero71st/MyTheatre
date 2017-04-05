using System.Collections.Generic;
using MyTheatre.Domain;
namespace MyTheatre.Web.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string ImagePath {get;set;}
        public string GenreId {get;set;}

        public IEnumerable<GenreViewModel> Genres {get;set;}

    }
}