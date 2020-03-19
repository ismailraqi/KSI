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
    class RegisterViewModel
    {
        ApiService apiService = new ApiService();
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await apiService.RegisterAsync(Username, Password, ConfirmPassword);
                    Settings.Username = Username;
                    Settings.Password = Password;
                    if (isSuccess)
                    {
                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        Message = "Try Again";
                    }
                });
            }
        }
    }
}
