using Muscles_app.Models;
using Muscles_app.Services;
using Muscles_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Content.ClipData;

namespace Muscles_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseTypePage : ContentPage
    {
        public  ExerciseTypePage()
        {
           


            InitializeComponent();
            BindingContext = new ExerciseTypeViewModel();
        }

     
    }
}