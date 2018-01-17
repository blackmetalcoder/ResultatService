using Newtonsoft.Json;
using ResultatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace ResultatService.Controllers
{
    public class ShortinfoArtistController : ApiController
    {
        // GET: api/ShortinfoArtist
        public string Get(string artist)
        {
            string svar = string.Empty;
            try
            {
                string bildQuery = "http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=" + artist + "&api_key=c5e414764357baf4097c59e86df16154";
                XmlDocument dokument = new XmlDocument();
                dokument.Load(bildQuery);
                /**/
                List<ArtistInfo> A = new List<ArtistInfo>();
                ArtistInfo a = new ArtistInfo();
                a.artist = artist;
                a.artistBild = dokument.GetElementsByTagName("image")[2].InnerText;
                a.InfoArtist = dokument.GetElementsByTagName("summary")[0].InnerText;
                A.Add(a);
                string sJson = JsonConvert.SerializeObject(A, Newtonsoft.Json.Formatting.Indented);
                return sJson;
            }
            catch (Exception ex)
            {
                return "FEL";
            }
        }

        // GET: api/ShortinfoArtist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShortinfoArtist
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShortinfoArtist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShortinfoArtist/5
        public void Delete(int id)
        {
        }
    }
}
