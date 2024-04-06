using Android.OS.Strictmode;
using Android.Text.Style;
using Muscles_app.Models;
using Muscles_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Muscles_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

            if ((await UserManaging.ReadAllAsync()).FirstOrDefault(x => x.Name == name && x.Password == pass) != null)
            {
              await Navigation.PushModalAsync(new HomePage());
            }
            else
            {
                FailureResult.IsVisible = true;
            }

            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());

        }
    }
}