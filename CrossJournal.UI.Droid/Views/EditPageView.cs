using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace CrossJournal.UI.Droid.Views
{
    [Activity(Label = "Edit")]
    public class EditPageView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EditPage);
        }
    }
}