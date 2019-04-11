namespace Instant.Training.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Instant.Training.UI.Utilities;

    [ValueConversion(typeof(string), typeof(object))]
    public class ArenaNameToImageConverter : IValueConverter
    {
        private readonly IResourceLocator _resourceLocator;

        public ArenaNameToImageConverter(IResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        public static ArenaNameToImageConverter Default = new ArenaNameToImageConverter(new ResourceLocator());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _resourceLocator.LocateResource((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}