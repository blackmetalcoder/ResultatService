using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultatService.Models
{

    public class RootTopalbum
    {
        public Topalbums topalbums { get; set; }
    }

    public class Topalbums
    {
        public Album[] album { get; set; }
        public Attr1 attr { get; set; }
    }

    public class Attr1
    {
        public string artist { get; set; }
        public string page { get; set; }
        public string perPage { get; set; }
        public string totalPages { get; set; }
        public string total { get; set; }
    }

    public class Album
    {
        public string name { get; set; }
        public int playcount { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public Artist artist { get; set; }
        public ImageTop[] image { get; set; }
    }

    public class ArtistTop
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
    }

    public class ImageTop
    {
        public string text { get; set; }
        public string size { get; set; }
    }

}