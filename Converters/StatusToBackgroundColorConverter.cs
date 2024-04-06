using Muscles_app.Models;
using System;
using Xamarin.Forms;


namespace Muscles_app.Converters
{
    public class StatusToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Status status)
            {
                switch (status)
                {
                    case Status.Waiting:
                        return Color.Transparent;
                    case Status.InProgress:
                        return Color.Yellow; // Change this to your desired color for InProgress status
                    case Status.Completed:
                        return Color.Green; // Change this to your desired color for Completed status
                    default:
                        return Color.Transparent;
                }
            }
            return Color.Transparent;
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
