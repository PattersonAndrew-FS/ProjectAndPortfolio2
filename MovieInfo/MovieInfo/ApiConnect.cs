using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
namespace MovieInfo
{
    public class ApiConnect
    {
        public ApiConnect()
        {
        }
        public List<Search> SearchTitle(string title)
        {
            List<Search> movies = null;
            string url = $"http://www.omdbapi.com/?apikey=80aa15d0&s={title}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                string json = response.Result.Content.ReadAsStringAsync().Result;
                SearchResult search = JsonConvert.DeserializeObject<SearchResult>(json);
                movies = search.Search;
            }
            return movies;

        }
    }
}
