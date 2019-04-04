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
	public class GetAllCompaniesPage : ContentPage
	{
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllCompaniesPage ()
		{
            this.Title = "Companies";

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
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
	}
}