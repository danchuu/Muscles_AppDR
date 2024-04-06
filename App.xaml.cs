using Muscles_app.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Muscles_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //  MainPage = new AppShell();

            MainPage = new NavigationPage(new LoginPage());
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black; //this makes the top bar black
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
