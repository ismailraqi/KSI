using ksi.Helpers;
using ksi.Models;
using ksi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ksi.ViewModels
{
    class AddArticleViewModel
    {
        ApiService apiService = new ApiService();
        public int UtilisateurID { get; set; }
        public string Titre_article { get; set; }
        public string Description { get; set; }
        public string Contenu_article { get; set; }
        public string Image { get; set; }
        public string Url_video { get; set; }
        public DateTime? Date_creation
        {
            get; set;
        }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var article = new AricleModel
                    {
                        UtilisateurID = UtilisateurID,
                        Titre_article = Titre_article,
                        Description = Description,
                        Contenu_article = Contenu_article,
                        Image = Image,
                        Url_video = Url_video,
                        Date_creation = DateTime.Now,
                    };
                    await apiService.PostArticleAsync(article, Settings.AccessToken);
                });
            }
        }
    }
}
