using ksi.Helpers;
using ksi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ksi.Models
{
    class AricleModel
    {
        public int ID { get; set; }
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
        
    }
}
