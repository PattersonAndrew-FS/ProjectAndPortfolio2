using System;
namespace SignInSignUp
{
    public class SignInSignUpService
    {

        public bool DoesUserNameExist(string userName)
        {
            return false;
        }
        public bool DoesEmailExist (string email)
        {
            return false;
        }
        public bool ArePasswordsTheSame(string password, string retypePassword)
        {
            return password.Equals(retypePassword);
        }
        public bool SignUp(string firstName, string lastName, string userName, string email, string password, string retypePassword)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
