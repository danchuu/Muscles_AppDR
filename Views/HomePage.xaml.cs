﻿using Android.Net;
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
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {

            InitializeComponent();
        }

        private async void StartWorkoutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new WorkoutPage());
        }
    }
}