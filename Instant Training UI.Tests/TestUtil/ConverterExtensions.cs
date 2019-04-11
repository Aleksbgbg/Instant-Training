namespace Instant.Training.UI.Tests.TestUtil
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using Moq;

    internal static class ConverterExtensions
    {
        internal static object Convert(this IValueConverter converter, object value)
        {
            return converter.Convert(value, It.IsAny<Type>(), It.IsAny<object>(), It.IsAny<CultureInfo>());
        }

        internal static object ConvertBack(this IValueConverter converter, object value)
        {
            return converter.ConvertBack(value, It.IsAny<Type>(), It.IsAny<object>(), It.IsAny<CultureInfo>());
        }
    }
}