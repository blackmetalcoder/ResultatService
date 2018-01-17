using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultatService.Models
{

    public class RootLiknande
    {
        public Similarartists similarartists { get; set; }
    }

    public class Similarartists
    {
        public Artist[] artist { get; set; }
        public Attr attr { get; set; }
    }

    public class Attr
    {
        public string artist { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string match { get; set; }
        public string url { get; set; }
        public Image[] image { get; set; }
        public string streamable { get; set; }
       
    }

    public class Image
    {
        public string text { get; set; }
        public string size { get; set; }
    }

}