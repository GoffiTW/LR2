using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Привязка_и_команды.Infrastructure
{
    public class ThemeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string theme = value as string;

            switch (theme)
            {
                case "Светлая":
                    return new SolidColorBrush(Color.FromRgb(245, 245, 245));
                case "Контрастная":
                    return new SolidColorBrush(Color.FromRgb(0, 0, 0));
                case "Спокойная":
                    return new SolidColorBrush(Color.FromRgb(219, 234, 254));
                default:
                    return new SolidColorBrush(Color.FromRgb(245, 245, 245));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ThemeToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string theme = value as string;

            switch (theme)
            {
                case "Светлая":
                    return new SolidColorBrush(Color.FromRgb(0, 0, 0));
                case "Контрастная":
                    return new SolidColorBrush(Color.FromRgb(255, 255, 255));
                case "Спокойная":
                    return new SolidColorBrush(Color.FromRgb(30, 64, 175));
                default:
                    return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}