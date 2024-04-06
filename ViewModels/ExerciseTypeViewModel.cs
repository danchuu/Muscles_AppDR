using Muscles_app.Models;
using Muscles_app.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Content.ClipData;
using static Java.Util.Jar.Attributes;

namespace Muscles_app.ViewModels
{
    public class ExerciseTypeViewModel : BaseViewModel
    {
        //Represents a dynamic data collection that provides notifications when items get added, removed,
        //or when the whole list is refreshed.


        public  List<ExerciseType> AllExerciseTypes 
        { 
            get
            { 
                return Task.Run(() => ExerciseTypeManager.ReadAllAsync()).GetAwaiter().GetResult().ToList();
            }
        }
        public ObservableRangeCollection<Grouping<Equipment,ExerciseType>> ExerciseTypesGroupsByEquipment { get; set; }
        public ObservableRangeCollection<Grouping<BodyParts, ExerciseType>> ExerciseTypesGroupsByBodyPart { get; set; }


        public AsyncCommand RefreshCommand { get;}

 
        public ExerciseTypeViewModel()
        {



        
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}