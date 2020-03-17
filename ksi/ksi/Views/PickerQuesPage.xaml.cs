using ksi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ksi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerQuesPage : ContentPage
	{
		public PickerQuesPage ()
		{
			InitializeComponent ();
            BindingContext = new PickerRepViewModel();
		}
	}
}