using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using CrossJournal.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace CrossJournal.UI.Droid.Views
{
    [Activity(Label = "All Notes")]
    public class MainPageView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);


        }
    }
}