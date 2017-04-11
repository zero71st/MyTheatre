using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyTheatre.Domain;
namespace MyTheatre.Web.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        [Required()]
        [DisplayName("ชื่อวีดีโอ")]
        public string Title { get; set; }
        [Required]
        [DisplayName("เรื่องย่อ")]
        public string Plot { get; set; }
        [DisplayName("ภาพ")]
        public string ImagePath {get;set;}
        [DisplayName("ประเภท")]
        public int GenreId {get;set;}

        public IEnumerable<GenreViewModel> Genres {get;set;}
    }
}