using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieInfo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            searchbar.SearchButtonPressed += Searchbar_SearchButtonPressed;
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
