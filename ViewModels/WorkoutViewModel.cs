using Muscles_app.Converters;
using Muscles_app.Models;
using Muscles_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Content.ClipData;

namespace Muscles_app.ViewModels
{

    public class WorkoutViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ExerciseType> _exerciseTypes;
        public ObservableCollection<ExerciseType> AvailableExerciseTypes
        {
            get { return _exerciseTypes; }
            set
            {
                if (_exerciseTypes != value)
                {
                    _exerciseTypes = value;
                    OnPropertyChanged();
                }
            }

        }
        private ObservableCollection<Exercise> _exercisesInGroup;
        public ObservableCollection<Exercise> ExercisesInGroup
        {
            get { return _exercisesInGroup; }
            set
            {
                if (_exercisesInGroup != value)
                {
                    _exercisesInGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        private ExerciseType _selectedExerciseType;
        public ExerciseType SelectedExerciseType
        {
            get { return _selectedExerciseType; }
            set
            {
                if (_selectedExerciseType != value)
                {
                    _selectedExerciseType = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Exercise> _exercises;
        public ObservableCollection<Exercise> Exercises
        {
            get { return _exercises; }
            set
            {
                if (_exercises != value)
                {
                    _exercises = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<ExerciseTypeGroup> _exerciseTypeGroups;
        public ObservableCollection<ExerciseTypeGroup> ExerciseTypeGroups
        {
            get { return _exerciseTypeGroups; }
            set
            {
                if (_exerciseTypeGroups != value)
                {
                    _exerciseTypeGroups = value;
                    OnPropertyChanged();
                }
            }
        }


        public WorkoutViewModel()
        {
            var exerciseTypeList = Task.Run(() => ExerciseTypeManager.ReadAllAsync()).GetAwaiter().GetResult().ToList();
            _exerciseTypes = new ObservableCollection<ExerciseType>(exerciseTypeList);
            ExerciseTypeGroups = new ObservableCollection<ExerciseTypeGroup>();

        }

    
        public ICommand CreateGroupCommand => new Command(CreateGroup);

        private void CreateGroup()
        {
            if (SelectedExerciseType == null)
            {
                // Handle the case where no exercise type is selected
                return;
            }

            // Check if a group already exists for the selected exercise type
            var existingGroup = ExerciseTypeGroups.FirstOrDefault(group => group.ExerciseType == SelectedExerciseType);

            if (existingGroup == null)
            {
                // If no group exists, create a new one
                var newGroup = new ExerciseTypeGroup
                {
                    ExerciseType = SelectedExerciseType,
                    ExercisesInGroup = new ObservableCollection<Exercise>()
                };

                ExerciseTypeGroups.Add(newGroup);
                existingGroup = newGroup;
            }

       
        }

        public ICommand DeleteItemCommand => new Command<Exercise>(OnDeleteItem);

        private void OnDeleteItem(Exercise exercise)
        {
            var exerciseTypeGroup = ExerciseTypeGroups.FirstOrDefault(group => group.ExercisesInGroup.Contains(exercise));
            if (exerciseTypeGroup != null)
            {
                exerciseTypeGroup.ExercisesInGroup.Remove(exercise);
            }
        }

        public ICommand CompleteExerciseCommand => new Command<Exercise>(CompleteExercise);
        private void CompleteExercise(Exercise exercise)
        {
            //if (exercise is Xamarin.Forms.Button)
            //{
            //    Button button = (Button)exercise;
            //    Grid row = button.Parent as Grid;
            //    row.BackgroundColor = StatusToBackgroundColorConverter.Convert(exercise.Status, exercise);
            //    Exercise exercise1 = row.

            //}
            exercise.Status = Status.Completed;
            
        }

        private ObservableCollection<string> _exerciseInfo;
        public ObservableCollection<string> ExerciseInfo
        {
            get {
                _exerciseInfo = new ObservableCollection<string>();
                var info = ExercisesInGroup.Select(x => new {Name = x.Name, Reps =x.Reps.ToString(), Weight =x.Weight.ToString()});
                foreach (var item in info)
                {
                    string line = $"{item.Name}, {item.Reps}, {item.Weight}";
                    _exerciseInfo.Add(line);
                }
                return _exerciseInfo;
            }
            set
            {
                if (_exerciseInfo != value)
                {
                    _exerciseInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddExerciseToGroupCommand => new Command(AddExerciseToGroup);
        private void AddExerciseToGroup(object sender)
        {
            var selectedGroup = ExerciseTypeGroups.FirstOrDefault(group => group.ExerciseType == sender);

            // Create a new exercise with default values
            var newExercise = new Exercise
            {
                Name = selectedGroup.ExerciseType.Name,
                Reps = null,  // Set default reps
                Weight = null // Set default weight
            };
    
            selectedGroup.ExercisesInGroup.Add(newExercise);

        }

        public ICommand CompleteWorkoutCommand => new Command<Workout>(CompleteWorkout);

        private void CompleteWorkout(Workout workout)
        {
            workout.Status = Status.Completed;
        }

        public ICommand DeleteGroupCommand => new Command(DeleteGroup);

        private async void DeleteGroup(object sender)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirmation", "Are you sure you want to delete this group?", "Yes", "No");
            if (answer)
            {
                var selectedgroup = ExerciseTypeGroups.FirstOrDefault(group => group == sender);
                ExerciseTypeGroups.Remove(selectedgroup);
            }
        }
           

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
