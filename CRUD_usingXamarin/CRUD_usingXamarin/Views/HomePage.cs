using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUD_usingXamarin.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();

            Button button = new Button();
            button.Text = "Add Company";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Get All Companies";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit Company";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);


            button = new Button();
            button.Text = "Delete Company";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);


            Content = stackLayout;
             
        }

        private async void Button_Clicked(object sender , EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());
        }
        
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompaniesPage());
        }
        
        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());
        }
        
    }
}