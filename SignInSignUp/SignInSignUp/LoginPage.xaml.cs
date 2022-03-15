using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SignInSignUp
{
    public partial class LoginPage : ContentPage
    {
        private SignInSignUpService signInSignUpService;
        public LoginPage()
        {
            InitializeComponent();
            signInSignUpService = new SignInSignUpService();
            signIn.Clicked += SignIn_Clicked;
            signUp.Clicked += SignUp_Clicked;
            forgotUserNamePassword.Clicked += ForgotUserNamePassword_Clicked;
        }

        private async void ForgotUserNamePassword_Clicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            string password = passwordEntry.Text;
            if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Username & Password Empty", "Please enter username or password", "Ok");
                return;
            }
            if(string.IsNullOrWhiteSpace(userName))
            {
                string userNameFound = signInSignUpService.FindUserName(password);
                if (userNameFound == null)
                {
                    await DisplayAlert("Could not find username", "We did not find a match for the password. Please try again.", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Username found", "Hint: " + userNameFound, "Ok");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                string passwordFound = signInSignUpService.FindPassword(userName);
                if (passwordFound == null)
                {
                    await DisplayAlert("Could not find Password", "We did not find a match for the username. Please try again.", "Ok");
                    return;
                }
                else
                {
                    await DisplayAlert("Password found", "Hint: " + passwordFound, "Ok");
                    return;
                }
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
           
           await Navigation.PushAsync(new RegisterPage());
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            string password = passwordEntry.Text;
            if (string.IsNullOrWhiteSpace(userName))
            {
                await DisplayAlert("Username is empty", "Username is empty", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Password is empty", "Password is empty", "Ok");
                return;
            }
            if(!signInSignUpService.DoesUserNameExist(userName))
            {
                await DisplayAlert("User does not exist", "Please try again or sign up", "Ok");
                return;
            }
            bool signInSuccess = signInSignUpService.SignIn(userName,password);
            if (signInSuccess )
            {
                await Navigation.PushAsync(new MainPage());
                
            }
            else
            {
                await DisplayAlert("Sign In Failed", "Username/Password is not correct","Ok");
            }
        }
    }
}
