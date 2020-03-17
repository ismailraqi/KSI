using ksi.Helpers;
using ksi.Models;
using ksi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ksi.ViewModels
{
    class ArticleViewModel : INotifyPropertyChanged
    {
        private ApiService apiService = new ApiService();
        private List<AricleModel> _articles;

        //public string AccessToken { get; set; }
        public List<AricleModel> Articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetArticles
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                   Articles = await apiService.GetArticleAsync(accesstoken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
                                                string propertyName =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    