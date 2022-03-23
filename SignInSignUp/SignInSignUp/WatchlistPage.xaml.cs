using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
/*
 * Andrew Patterson
 * March 23 2022
 * 4.1 - Code: Beta
 * P&P2
 */
namespace SignInSignUp
{
    public partial class WatchlistPage : ContentPage
    {
        //Create watchlist
        private WatchListService watchListService;
        private List<WatchlistRow> watchlist;
        public WatchlistPage()
        {
            InitializeComponent();
            watchListService = new WatchListService();
            watchlist = watchListService.GetWatchlist();
            watchlistView.ItemsSource = watchlist;
            deleteMovie.Clicked += DeleteMovie_Clicked;
        }
        //Alerts for watchlist
        private  async void DeleteMovie_Clicked(object sender, EventArgs e)
        {

            var btn = (Xamarin.Forms.Button)sender;
            string movieToDelete = btn.CommandParameter.ToString();
            bool success = watchListService.RemoveFromWatchlist(movieToDelete);
            if(success )
            {
                await DisplayAlert("Movie removed from watchlist", "Movie has been removed from watchlist successfully", "Ok");
            }
            else
            {
                await DisplayAlert("Failed to remove movie", "Failed to remove movie from watchlist. Please try again", "Ok");
            }
            
        }
    }
}
