using ksi.Services;
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
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await apiService.RegisterAsync(Email, Password, ConfirmPassword);
                    if (isSuccess)
                    {
                        Message = "Register Success";
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
