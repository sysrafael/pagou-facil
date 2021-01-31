using System.Collections.Generic;

namespace PagouFacil.Business
{
    public class MarvelContentLists
    {
        public List<string> comics { get; private set; }
        public List<string> stories { get; private set; }
        public List<string> events { get; private set; }
        public List<string> series { get; private set; }

        public MarvelContentLists(
            List<string> comics, 
            List<string> stories, 
            List<string> events, 
            List<string> series)
        {
            this.comics = comics;
            this.stories = stories;
            this.events = events;
            this.series = series;
        }
    }
}
