using System;

using System.Collections.Generic;
using System.IO;

namespace SignInSignUp
{
    public class SignInSignUpService
    {
        private List<User> users;
        private string filePath;
        public SignInSignUpService()
        {
            filePath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
            users = ReadUsersFromFile();
        }
        public List<User> ReadUsersFromFile()
        {
            List<User> userList = new List<User>();
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string row = null;
                do
                {
                    row = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(row))
                    {
                        User user = new User();
                        string[] sections = row.Split('|');
                        user.FirstName = sections[0];
                        user.LastName = sections[1];
                        user.UserName = sections[2];
                        user.Email = sections[3];
                        user.Password = sections[4];
                        userList.Add(user);
                    }

                } while (!string.IsNullOrEmpty(row));
               
            }
            return userList;
        }
        public void WriteUsersToFile()
        {
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                foreach (var item in users)
                {
                    string row = $"{item.FirstName}|{item.LastName}|{item.UserName}|{item.Email}|{item.Password}";
                    streamWriter.WriteLine(row);
                }
            }
        }
        public bool DoesUserNameExist(string userName)
        {
            foreach (var item in users)
            {
                if (item.UserName.Equals(userName))
                {
                    return true;
                }

            }
            return false;
        }
        public bool DoesEmailExist (string email)
        {
            foreach (var item in users)
            {
                if (item.Email.Equals(email))
                {
                    return true;
                }

            }
            return false;
        }
        public bool ArePasswordsTheSame(string password, string retypePassword)
        {
            return password.Equals(retypePassword);
        }
        public bool SignUp(string firstName, string lastName, string userName, string email, string password)
        {
            try
            {
                User newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName,
                    Email = email,
                    Password = password
                };
                users.Add(newUser);
                WriteUsersToFile();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SignIn(string userName, string password)
        {
            foreach (var item in users)
            {
                if (item.UserName.Equals(userName) && item.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
        public string FindUserName(string password)
        {
            foreach (var item in users)
            {
                if (item.Password.Equals(password))
                {
                    return item.UserName;
                }

            }
            return null;
        }
        public string FindPassword(string userName)
        {
            foreach (var item in users)
            {
                if (item.UserName.Equals(userName))
                {
                    return item.Password;
                }

            }
            return null;
        }
    }
}
