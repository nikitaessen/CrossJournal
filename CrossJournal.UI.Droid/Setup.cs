using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using CrossJournal.Core;
using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Managers;
using CrossJournal.Core.Models;
using CrossJournal.UI.Droid.Managers;
using MvvmCross.Platform;

namespace CrossJournal.UI.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new JournalApp();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.ConstructAndRegisterSingleton<IStorageSerializer<Record>, XmlStorageSerializer>();
            Mvx.ConstructAndRegisterSingleton<IStorageManager, LocalStorageManager>();
            Mvx.ConstructAndRegisterSingleton<IRecordingsManager, RecordingsManager>();
            Mvx.ConstructAndRegisterSingleton<IAttachmentManager,AttachmentManager>();
        }
    }
}