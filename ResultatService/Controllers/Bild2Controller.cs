using HtmlAgilityPack;
using Newtonsoft.Json;
using ResultatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ResultatService.Controllers
{
    [EnableCors(origins: "http://resultatservice.azurewebsites.net", headers: "*", methods: "*")]
    public class Bild2Controller : ApiController
    {
        // GET: api/Bild2
        public string Get(string artist)
        {
            string NyArtist = Plusa(artist);
            System.Net.WebClient wc = new System.Net.WebClient();
            List<Bilder> B = new List<Bilder>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string address = "https://www.last.fm/sv/music/" + NyArtist + "/+images";
            doc.Load(wc.OpenRead(address));
            HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//ul[@class='image-list']//img[@src]");
            foreach (HtmlNode img in imgs)
            {
                if (img.Attributes["src"] == null)
                    continue;
                HtmlAttribute src = img.Attributes["src"];
                Bilder b = new Bilder();
                b.kalla = src.Value;
                B.Add(b);

            }
            string sJson = JsonConvert.SerializeObject(B, Newtonsoft.Json.Formatting.Indented);
            return sJson;
        }
        public static string Plusa(string p)
        {
            //Läggert ett plus
            p = p.Replace(" ", "+");
            return p;
        }
        // GET: api/Bild2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bild2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bild2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bild2/5
        public void Delete(int id)
        {
        }
    }
}
