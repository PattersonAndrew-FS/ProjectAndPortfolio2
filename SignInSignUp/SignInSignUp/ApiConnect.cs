using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
/*
 * Andrew Patterson
 * March 23 2022
 * 4.1 - Code: Beta
 * P&P2
 */
namespace SignInSignUp
{
    public class ApiConnect
    {
        public ApiConnect()
        {
        }
        //API connection
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
        //API details
        public MovieDetail GetMovieDetail(string imdbid)
        {
            MovieDetail movieDetail = null;
            string url = $"http://www.omdbapi.com/?apikey=80aa15d0&i={imdbid}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                string json = response.Result.Content.ReadAsStringAsync().Result;
                movieDetail = JsonConvert.DeserializeObject<MovieDetail>(json);

            }
            return movieDetail;
        }
    }
}
