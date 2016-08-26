using CrossJournal.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace CrossJournal.Core
{
    public class JournalApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainPageViewModel>());
        }
    }
}
