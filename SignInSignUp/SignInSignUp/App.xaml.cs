using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignInSignUp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // new navigation page
            MainPage = new NavigationPage( new RegisterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
