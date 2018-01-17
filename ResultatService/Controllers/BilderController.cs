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
    public class BilderController : ApiController
    {
        // GET: api/Bilder
        public string Get(string artist)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            List<Bilder> B = new List<Bilder>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //string address = "https://www.bing.com/images/search?q=" + artist + "&qs=n&form=QBLH&scope=images&sp=-1&pq=" + artist + "&sc=8-6&sk=&cvid=B2B4DF8C73B444D398CA63F6317AC5D3";
            //string address = "https://www.google.com/search?q=" + artist + "&tbm=isch&gws_rd=cr&ei=16E0WMGSKYmisAHmp6b4Ag";
            string address = "http://images.search.yahoo.com/search/images;_ylt=AwrDQ3J1CF1ZqHIA0hH7w8QF?p=" + artist + "&fr=sfp&fr2=p%3As%2Cv%3Av%2Cm%3Apivot";
            doc.Load(wc.OpenRead(address));
            HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img[@src]");
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

        // GET: api/Bilder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bilder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bilder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bilder/5
        public void Delete(int id)
        {
        }
    }
}
