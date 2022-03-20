using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SignInSignUp
{
    //Create new mainpage
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            searchbar.SearchButtonPressed += Searchbar_SearchButtonPressed;
            searchresults.ItemSelected += Searchresults_ItemSelected;
        }

        private async void Searchresults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Search search = e.SelectedItem as Search;
            MovieDetailPage movieDetailPage = new MovieDetailPage(search.imdbID);
            await Navigation.PushAsync(movieDetailPage);
        }

        private void Searchbar_SearchButtonPressed(object sender, EventArgs e)
        {
            string movieName = ((SearchBar)sender).Text;
            ApiConnect apiConnect = new ApiConnect();
            var movies = apiConnect.SearchTitle(movieName);
            searchresults.ItemsSource = movies;


        }
    }
}
