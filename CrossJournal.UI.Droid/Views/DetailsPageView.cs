using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using MvvmCross.Droid.Views;
using System.Collections.Generic;
using Android.Provider;
using Android.Views;
using Java.IO;
using Uri = Android.Net.Uri;

namespace CrossJournal.UI.Droid.Views
{
    [Activity(Label = "Details")]
    public class DetailsPageView : MvxActivity
    {
        private IAttachmentManager AttachManager { get; set; }

        private void ChooseImageToAttach()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select image"), 0);
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakePhoto()
        {
            if (IsThereAnAppToTakePictures())
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                App.File = new File(string.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App.File));
                StartActivityForResult(intent, 0);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Details);

            var imageButton = FindViewById<Button>(Resource.Id.attachImageButton);
            imageButton.Click += delegate { ChooseImageToAttach(); };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                //var path = new ImagePath() { FullPath = data.Data.Path, Id = AttachManager.IdGenerator.Next() };
                //AttachManager.ImagesPath.Add(path);

            }
        }
    }

    public static class App
    {
        public static File File;
    }
}