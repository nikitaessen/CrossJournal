using MvvmCross.Platform.Converters;
using System;
using System.Globalization;

namespace CrossJournal.UI.Droid.Converters
{
    public class TimeSpanToHumanStringDroid : MvxValueConverter<DateTime,string>
    {
        protected override string Convert(DateTime when, Type targetType, object parameter, CultureInfo culture)
        {
                DateTime itemDate = new DateTime();

                var str = when.ToString();

                itemDate = DateTime.ParseExact(str, "dd.MM.yyyy H:mm:ss", null);
                var diff = DateTime.Now.Subtract(itemDate);

                int dayDiff = (int)diff.TotalDays;
                int secDiff = (int)diff.TotalSeconds;

                if (dayDiff == 0)
                {
                    // Less than one minute ago.
                    if (secDiff < 60)
                    {
                        return "just now";
                    }
                    // Less than 2 minutes ago.
                    if (secDiff < 120)
                    {
                        return "1 minute ago";
                    }
                    // Less than one hour ago.
                    if (secDiff < 3600)
                    {
                        return string.Format("{0} minutes ago",
                            Math.Floor((double)secDiff / 60));
                    }
                    // Less than 2 hours ago.
                    if (secDiff < 7200)
                    {
                        return "1 hour ago";
                    }
                    // Less than one day ago.
                    if (secDiff < 86400)
                    {
                        return string.Format("{0} hours ago",
                            Math.Floor((double)secDiff / 3600));
                    }
                }
                return string.Format("{0} days ago",
                            Math.Floor((double)dayDiff / 1));
         }
    }
}
