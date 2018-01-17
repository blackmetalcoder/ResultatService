using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;
using ResultatService.Models;
using System.IO;
using System.Text;

namespace ResultatService.Controllers
{
    [EnableCors(origins: "http://resultatservice.azurewebsites.net", headers: "*", methods: "*")]
    public class ArtistController : ApiController
    {
        public String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = this.GetImage(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }
        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }
        // GET: api/Artist
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
                a.InfoArtist = dokument.GetElementsByTagName("content")[0].InnerText;
                string B64 = ConvertImageURLToBase64(a.artistBild);
                a.bild64 = B64;
                A.Add(a);
                string sJson = JsonConvert.SerializeObject(A, Newtonsoft.Json.Formatting.Indented);
                return sJson;
            }
            catch (Exception ex)
            {
                return "FEL";
            }
           
        }

        // GET: api/Artist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Artist
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Artist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Artist/5
        public void Delete(int id)
        {
        }
    }
}
