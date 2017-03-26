using System.Collections.Generic;

namespace MyTheatreApi.Models
{
    public class VideoContext
    {
        private IList<Video> _videos;
        public IList<Video> Videos   
        { 
            get 
            { 
                _videos = new List<Video>()
                {
                    new Video { Id = 1,Title = "Avatar" },
                    new Video { Id = 2,Title = "Transformer" },
                    new Video { Id = 3,Title = "Again" },
                };

                return _videos;
            }
            set { _videos = value;}
        }
    }
}