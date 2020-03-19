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
            //LoadPickerData();

		}

        



        //private void LoadPickerData()
        //{

        //    // ALL Rep
        //    var repList = new List<RepModel>();
        //    // Question No 1
        //    var rep = new RepModel
        //    {
        //        Id = 11,
        //        Rep = "Rep 1"
        //    };
        //    repList.Add(rep);


        //    // Question No 2
        //    var rep2 = new RepModel
        //    {
        //        Id = 12,
        //        Rep = "Rep 2"
        //    };
        //    repList.Add(rep2);


        //    // Question No 3
        //    var rep3 = new RepModel
        //    {
        //        Id = 13,
        //        Rep = "Rep 3"
        //    };
        //    repList.Add(rep3);
        //    Qst1.ItemsSource = repList.ToList();






        //}


    }
}