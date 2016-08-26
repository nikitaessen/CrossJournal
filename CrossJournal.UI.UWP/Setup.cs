using Windows.UI.Xaml.Controls;
using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Managers;
using CrossJournal.UI.UniversalWindows.Managers;
using CrossJournal.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.WindowsUWP.Platform;
using MvvmCross.Plugins.Messenger;
using CrossJournal.UI.UWP.Managers;

namespace CrossJournal.UI.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.JournalApp();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterSingleton<IMvxMessenger>(new MvxMessengerHub());
            Mvx.ConstructAndRegisterSingleton<IStorageSerializer<Record>, XmlStorageSerializer>();
            Mvx.ConstructAndRegisterSingleton<IStorageManager, LocalStorageManager>();
            Mvx.ConstructAndRegisterSingleton<IAttachmentManager, AttachmentManager>();
            Mvx.ConstructAndRegisterSingleton<IRecordingsManager, RecordingsManager>();
        }
    }
}