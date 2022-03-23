using System;
using System.Collections.Generic;

using Xamarin.Forms;
/*
 * Andrew Patterson
 * March 23 2022
 * 4.1 - Code: Beta
 * P&P2
 */
namespace SignInSignUp
{
    public partial class MovieDetailPage : ContentPage
    {
        private WatchListService watchListService;
        public MovieDetailPage(string imdbid)
        {
            //create new api and get details
            InitializeComponent();
            ApiConnect apiConnect = new ApiConnect();
            watchListService = new WatchListService();
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

                addToWatchListBtn.Clicked += AddToWatchListBtn_Clicked;
              
            }
           
            
        }
        //Alerts for watchlist
        
        private async void AddToWatchListBtn_Clicked(object sender, EventArgs e)
        {
            string title = titleLabel.Text;
            if(watchListService.DoesTitleExist(title))
            {
                await DisplayAlert("This movie is already in your watchlist","This movie is already in your watchlist", "Ok");
                return;
            }
            bool success = watchListService.AddToWatchlist(title);
            if(success)
            {
                await DisplayAlert("Movie added to watchlist", "Movie added to watchlist", "Ok");
                WatchlistPage watchlistPage = new WatchlistPage();
                await Navigation.PushAsync(watchlistPage);
            }
            else
            {
                await DisplayAlert("Failed to add to watchlist", "Failed to add to watchlist, please try again", "Ok");
            }
            
        }
    }
}
