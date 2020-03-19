using ksi.Helpers;
using ksi.Services;
using ksi.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ksi.ViewModels
{
    class LoginViewModel
    {
        private ApiService apiService = new ApiService();
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var accesstoken = await apiService.LoginAsync(Username, Password);
                    Settings.AccessToken = accesstoken;
                    if (!string.IsNullOrEmpty(Settings.AccessToken))
                    {
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }
                });
            }
        }



        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
