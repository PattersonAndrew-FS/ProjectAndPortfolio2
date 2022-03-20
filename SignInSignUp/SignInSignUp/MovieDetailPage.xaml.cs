using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SignInSignUp
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(string imdbid)
        {
            InitializeComponent();
            ApiConnect apiConnect = new ApiConnect();
            MovieDetail movieDetail = apiConnect.GetMovieDetail(imdbid);
            if(movieDetail != null)
            {
                titleLabel.Text = movieDetail.Title;
                year.Text = movieDetail.Year;
                rated.Text = movieDetail.Rated;
                released.Text = movieDetail.Released;
                runtime.Text = movieDetail.Runtime;
                genre.Text = movieDetail.Genre;
                director.Text = movieDetail.Director;
                writer.Text = movieDetail.Writer;
                actors.Text = movieDetail.Actors;
                plot.Text = movieDetail.Plot;
                year.Text = movieDetail.Year;
                year.Text = movieDetail.Year;
                year.Text = movieDetail.Year;

            }
           
            
        }
    }
}
