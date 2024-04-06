using Muscles_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Muscles_app.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to check if the current user has a certain role


        //private UserRole GetUserRole()
        ////{
            // Implement logic to retrieve the user's role (e.g., from a database, claims, etc.)
            // For simplicity, let's assume it's retrieved from a global variable or stored locally
            // Replace this with your actual implementation
            //return UserRole.User; // Example
            
        //}

        // Example property for binding to UI elements
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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}