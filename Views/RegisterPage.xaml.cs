using Android.OS;
using System;
using Muscles_app.Services;
using Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Muscles_app.Models;
using System.Threading.Tasks;

namespace Muscles_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

           Task.Run(()=>UserManaging.CreateAsync(new User(name, pass))).GetAwaiter().GetResult();
            await Navigation.PushAsync(new HomePage());
        }
    }
}