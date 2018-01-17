using ResultatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ResultatService.Controllers
{
    [EnableCors(origins: "http://resultatservice.azurewebsites.net", headers: "*", methods: "*")]
    public class LiknandeController : ApiController
    {
        // GET: api/Liknande
        //public  string Get(string artist)
        public async Task<string> Get(string artist)
        {
            try
            {
                List<LikandeArtister> L = new List<LikandeArtister>();
                var client = new HttpClient();
                var uri = new Uri("http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=" + artist + "&api_key=c5e414764357baf4097c59e86df16154&format=json");
                var Response = await client.GetAsync(uri);
                var ResponseText = Response.Content.ReadAsStringAsync();
                var s = ResponseText.Result;
                s = s.Replace("#", "");
                var Lik = JsonConvert.DeserializeObject<RootLiknande>(s);
                int antal = Lik.similarartists.artist.Count();
                for (int i=0; i < Lik.similarartists.artist.Count(); i++)
                {
                    LikandeArtister l = new LikandeArtister();
                    l.namn = Lik.similarartists.artist[i].name;
                    l.infoURL = Lik.similarartists.artist[i].url;
                    var bild = Lik.similarartists.artist[i].image;
                    l.bild = bild[4].text;
                    //string b64 = img64.ConvertImageURLToBase64(l.bild);
                    //l.bild64 = b64;
                    L.Add(l);
                }
                var kk = Lik;
                string BildQuery = "http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=" + artist + "&api_key=c5e414764357baf4097c59e86df16154&format=json";
                 
                
                string sJson = JsonConvert.SerializeObject(L, Newtonsoft.Json.Formatting.Indented);
                return sJson;
            }
            catch(Exception ex)
            {
                return "fel";
            }
        }

        // GET: api/Liknande/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Liknande
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Liknande/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Liknande/5
        public void Delete(int id)
        {
        }
    }
}
