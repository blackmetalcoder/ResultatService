using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using ResultatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResultatService.Controllers
{
    public class VideoController : ApiController
    {
        // GET: api/Video
        public async System.Threading.Tasks.Task<string> GetAsync(string artist)
        {
            List<videoLista> A = new List<videoLista>();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCtjWcVfhCZnbQ--a1EfoAnBixsEd7y5CY",
                //ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = artist; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        {
                            videoLista a = new videoLista();
                            a.Id = searchResult.Id.VideoId;
                            a.Title = searchResult.Snippet.Title;
                            A.Add(a);
                            break;
                        }
                }
            }
            string sJson = JsonConvert.SerializeObject(A, Newtonsoft.Json.Formatting.Indented);
            return sJson;
        }

        // GET: api/Video/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Video
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
