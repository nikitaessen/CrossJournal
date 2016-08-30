using MvvmCross.Platform.Converters;
using System;

namespace CrossJournal.Core.Converters
{
    public class StringToUriConverter : MvxValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, string language)
        {
                var res = new Uri((string)value, UriKind.Absolute);
                return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
