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
    public class AlbumController : ApiController
    {
        // GET: api/Album
        public string Get(string artist, string album)
        {
            string svar = string.Empty;
            try
            {
                string bildQuery = "http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=c5e414764357baf4097c59e86df16154&artist=" + artist + "&album=" + album;
                XmlDocument dokument = new XmlDocument();
                dokument.Load(bildQuery);
                /**/
                List<ArtistInfo> A = new List<ArtistInfo>();
                ArtistInfo a = new ArtistInfo();
                a.artist = artist;
                a.artistBild = dokument.GetElementsByTagName("image")[3].InnerText;
                string b64 = img64.ConvertImageURLToBase64(a.artistBild);
                a.bild64 = b64;
                a.InfoArtist = dokument.GetElementsByTagName("content")[0].InnerText;
                A.Add(a);
                string sJson = JsonConvert.SerializeObject(A, Newtonsoft.Json.Formatting.Indented);
                return sJson;
            }
            catch (Exception ex)
            {
                return "FEL";
            }
        }

        // GET: api/Album/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Album
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Album/5
        public void Delete(int id)
        {
        }
    }
}
