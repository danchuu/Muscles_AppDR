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
	public partial class AddExerciseTypePage : ContentPage
	{
		public AddExerciseTypePage ()
		{
            

            InitializeComponent ();

            List<string> equipmentList = ((Equipment[])Enum.GetValues(typeof(Equipment))).Select(c => c.ToString()).ToList();
            equipmentPicker.ItemsSource = equipmentList;
            List<string> bodyPartList = ((BodyParts[])Enum.GetValues(typeof(BodyParts))).Select(c => c.ToString()).ToList();
            bodyPartPicker.ItemsSource = bodyPartList;

        }

        private async void AddExerciseTypeButton_Clicked(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            Equipment equipment = (Equipment)Enum.Parse(typeof(Equipment), (string)equipmentPicker.SelectedItem, true);
            BodyParts bodypart = (BodyParts)Enum.Parse(typeof(BodyParts), (string)bodyPartPicker.SelectedItem, true);

            await ExerciseTypeManager.CreateAsync(new ExerciseType(name,description,bodypart,equipment));
        }
    }
}