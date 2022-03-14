using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SignInSignUp
{
    public partial class RegisterPage : ContentPage
    {
        private SignInSignUpService signInSignUpService;
        public RegisterPage()
        {
            InitializeComponent();
            signInSignUpService = new SignInSignUpService();
            signUp.Clicked += SignUp_Clicked;
            signIn.Clicked += SignIn_Clicked;
        }

        private void SignIn_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            string userName = userNameEntry.Text;
            bool userNameExist = signInSignUpService.DoesUserNameExist(userName);
            if (userNameExist)
            {
                await DisplayAlert("User name is taken","This user name is taken, please choose another one.","Ok");
                return;
            }

            string email = emailEntry.Text;
            bool emailExist = signInSignUpService.DoesEmailExist(email);
            if (emailExist)
            {
                await DisplayAlert("Email is taken", "This email is taken, please choose another one.", "Ok");
                return;
            }

            string password = passwordEntry.Text;
            string retypePassword = reTypePasswordEntry.Text;
            bool passwordsTheSame = signInSignUpService.ArePasswordsTheSame(password,retypePassword);
            if (!passwordsTheSame)
            {
                await DisplayAlert("Passwords are not the same", "Passwords are not the same, please fix.", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                await DisplayAlert("User name is empty.", "User name is empty.", "Ok");
                return;
            }
            string firstName = firstNameEntry.Text;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                await DisplayAlert("First name is empty.", "First name is empty.", "Ok");
                return;
            }
            string lastName = lastNameEntry.Text;

            if (string.IsNullOrWhiteSpace(lastName))
            {
                await DisplayAlert("Last name is empty.", "Last name is empty.", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Email is empty.", "Email is empty.", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Password is empty.", "Password is empty.", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(retypePassword))
            {
                await DisplayAlert("Re-Type Password is empty.", "Re-Type Password is empty.", "Ok");
                return;
            }

            bool signUpSuccess = signInSignUpService.SignUp(firstName, lastName, userName, email, password, retypePassword);

            if (signUpSuccess )
            {
                await DisplayAlert("Thank you for signing up.", "Thank you for signing up.", "Ok");
               await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
