using MvvmCross.Platform.Converters;
using System;
using System.Globalization;

namespace CrossJournal.Core.Converters
{
    public class MultilineToSingle : MvxValueConverter<string>
    {
        private const string TextFormat = "{0}\n{1}...";
        string _outputText = null;

        protected override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;

            var inputText = value.ToString();

            if (inputText.Contains("\n"))
            {
                var buff = (inputText.Split('\n'))[0];
                _outputText = (inputText.Split('\n'))[1];

                return String.Format(TextFormat, buff, _outputText);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("You cannot convert back a short text the information would be lost...");
        }
    }
}