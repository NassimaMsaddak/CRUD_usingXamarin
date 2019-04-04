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
	public class EditCompanyPage : ContentPage
	{
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _button;

        Company _company = new Company();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public EditCompanyPage ()
		{
            this.Title = "Edit Company";

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

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
             stackLayout.Children.Add(_nameEntry);


            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Company company = new Company()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Adress = _addressEntry.Text, 
            };

            db.Update(company);
            await Navigation.PopAsync();

        }



        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company =(Company)e.SelectedItem;
            _idEntry.Text = _company.Id.ToString();
            _nameEntry.Text = _company.Name;
            _addressEntry.Text = _company.Adress;
        }


    }
}