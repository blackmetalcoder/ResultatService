using Newtonsoft.Json;
using ResultatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;
using System.Xml.Linq;

namespace ResultatService.Controllers
{
    [EnableCors(origins: "http://resultatservice.azurewebsites.net", headers: "*", methods: "*")]
    public class TopalbumsController : ApiController
    {
        // GET: api/Topalbums
        public async Task<string> Get(string artist)
        {
           
            List<topAlbums> L = new List<topAlbums>();
            var client = new HttpClient();
            var uri = new Uri("http://ws.audioscrobbler.com/2.0/?method=artist.gettopalbums&artist=" + artist + "&api_key=c5e414764357baf4097c59e86df16154&format=json");
            var Response = await client.GetAsync(uri);
            var ResponseText = Response.Content.ReadAsStringAsync();
            var s = ResponseText.Result;
            s = s.Replace("#", "");
            var Lik = JsonConvert.DeserializeObject<RootTopalbum>(s);
            var k = Lik;
            for (int i = 0; i < Lik.topalbums.album.Count(); i++)
            {
                topAlbums l = new topAlbums();
                l.Album= Lik.topalbums.album[i].name;
                var bild = Lik.topalbums.album[i].image;
                l.Coverart = bild[3].text;
                //string b64 = img64.ConvertImageURLToBase64(l.Coverart);
                //Nytt
                //l.bild64 = b64;
                L.Add(l);
            }
            string sJson = JsonConvert.SerializeObject(L, Newtonsoft.Json.Formatting.Indented);
            return sJson;
        }

        // GET: api/Topalbums/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Topalbums
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Topalbums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topalbums/5
        public void Delete(int id)
        {
        }
    }
}
