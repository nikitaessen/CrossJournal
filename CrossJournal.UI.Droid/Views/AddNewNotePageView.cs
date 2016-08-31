using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace CrossJournal.UI.Droid.Views
{
    [Activity(Label = "New Note")]
    public class AddNewNotePageView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddNewNote);
        }
    }
}