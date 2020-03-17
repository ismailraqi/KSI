﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ksi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticlesPage : ContentPage
	{
		public ArticlesPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddArticlePage());
        }
    }
}