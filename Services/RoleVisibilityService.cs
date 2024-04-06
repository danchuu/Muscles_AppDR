using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Muscles_app.Services
{
   
    public class RoleVisibilityService : INotifyPropertyChanged
    {
        private bool isAdminVisible;
        public bool IsAdminVisible
        {
            get { return isAdminVisible; }
            set
            {
                if (isAdminVisible != value)
                {
                    isAdminVisible = value;
                    OnPropertyChanged(nameof(IsAdminVisible));
                }
            }
        }

        // Other properties and logic for handling visibility based on roles

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
