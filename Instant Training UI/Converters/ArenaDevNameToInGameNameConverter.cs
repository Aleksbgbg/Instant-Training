namespace Instant.Training.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    [ValueConversion(typeof(string), typeof(string))]
    public class ArenaDevNameToInGameNameConverter : IValueConverter
    {
        public static ArenaDevNameToInGameNameConverter Default { get; } = new ArenaDevNameToInGameNameConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Constants.ArenaDevToInGameNameMappings[(string)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}