using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      
        private ObservableCollection<WatchlistRow> watchlistCollection;
        public WatchlistPage()
        {
            InitializeComponent();
            watchListService = new WatchListService();
            List<WatchlistRow> watchlist = watchListService.GetWatchlist();
            watchlistCollection = new ObservableCollection<WatchlistRow>(watchlist);
            watchlistView.ItemsSource = watchlistCollection;
          
        }
        //Alerts for watchlist
        private  async void DeleteMovie_Clicked(object sender, EventArgs e)
        {

            var btn = (Xamarin.Forms.Button)sender;
            string movieToDelete = btn.CommandParameter.ToString();
            bool success = watchListService.RemoveFromWatchlist(movieToDelete);
            if(success )
            {
                WatchlistRow watchlistRowToDelete = null;
                foreach (var item in watchlistCollection)
                {
                    if(item.Title.Equals(movieToDelete))
                    {
                        watchlistRowToDelete = item;
                    }
                }
                if(watchlistRowToDelete !=null)
                {
                    
                    watchlistCollection.Remove(watchlistRowToDelete);
                }
                await DisplayAlert("Movie removed from watchlist", "Movie has been removed from watchlist successfully", "Ok");
                
            }
            else
            {
                await DisplayAlert("Failed to remove movie", "Failed to remove movie from watchlist. Please try again", "Ok");
            }
            
        }
    }
}
