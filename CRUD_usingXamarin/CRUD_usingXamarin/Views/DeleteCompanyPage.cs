using CRUD_usingXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUD_usingXamarin.Views
{
	public class DeleteCompanyPage : ContentPage
	{
        private ListView _listView; 
        private Button _button;

        Company _company = new Company();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public DeleteCompanyPage ()
		{
            this.Title = "Delete Company";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    Label addressLabel = new Label();
                    addressLabel.SetBinding(Label.TextProperty, "Adress");
                    addressLabel.TextColor = Color.FromHex("#ff0000");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(20, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                    {

                                        new StackLayout
                                        {
                                            VerticalOptions = LayoutOptions.Center,
                                            Spacing = 0,
                                            Children =
                                            {
                                                nameLabel,
                                                addressLabel,
                                            }
                                        }
                                    }
                        }
                    };
                })
            };
            _listView.HasUnevenRows = true;
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);
             
            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }


        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Company>().Delete(x => x.Id == _company.Id);
            await Navigation.PopAsync();

        }


        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = (Company)e.SelectedItem; 
        }
    }
}