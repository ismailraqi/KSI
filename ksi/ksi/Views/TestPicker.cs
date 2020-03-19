using ksi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ksi.Views
{
	public class TestPicker : ContentPage
	{
        private Picker _picker;
        private Button _button;
        private Entry _entry;
		public TestPicker ()
		{
            this.Title = "Test Page";
            List<RepModel> repModels = new List<RepModel>();
            repModels.Add(new RepModel() { Id = 11, Rep = "Reponse 1" });
            repModels.Add(new RepModel() { Id = 12, Rep = "Reponse 2" });
            repModels.Add(new RepModel() { Id = 13, Rep = "Reponse 3" });

            StackLayout stackLayout = new StackLayout();
            _picker = new Picker();
            _picker.Title = "Select Reponse";
            _picker.ItemsSource = repModels;
            stackLayout.Children.Add(_picker);

            _button = new Button();
            _button.Text = "Show Result";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            _entry = new Entry();
            _entry.Keyboard = Keyboard.Text;
            _entry.Placeholder = "Picker Selected Id";
            stackLayout.Children.Add(_entry);

            Content = stackLayout;
        }

        private void _button_Clicked(object sender, EventArgs e)
        {
            _entry.Text = _picker.SelectedItem.ToString();
        }
    }
}