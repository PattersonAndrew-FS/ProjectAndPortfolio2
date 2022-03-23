using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
/*
 * Andrew Patterson
 * March 23 2022
 * 4.1 - Code: Beta
 * P&P2
 */
namespace SignInSignUp
{
    //Create new mainpage
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //This is when the search bar is activated
            InitializeComponent();
            searchbar.SearchButtonPressed += Searchbar_SearchButtonPressed;
            searchresults.ItemSelected += Searchresults_ItemSelected;
            viewWatchlistBtn.Clicked += ViewWatchlistBtn_Clicked;
        }

        private async void ViewWatchlistBtn_Clicked(object sender, EventArgs e)
        {
            WatchlistPage watchlistPage = new WatchlistPage();
            await Navigation.PushAsync(watchlistPage);
        }

        //Getting movie details from api
        private async void Searchresults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Search search = e.SelectedItem as Search;
            MovieDetailPage movieDetailPage = new MovieDetailPage(search.imdbID);
            await Navigation.PushAsync(movieDetailPage);
        }
        // When something is typed into the search bar
        private void Searchbar_SearchButtonPressed(object sender, EventArgs e)
        {
            string movieName = ((SearchBar)sender).Text;
            ApiConnect apiConnect = new ApiConnect();
            var movies = apiConnect.SearchTitle(movieName);
            searchresults.ItemsSource = movies;


        }
    }
}
