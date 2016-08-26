using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace CrossJournal.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private IMvxMessenger _messenger = Mvx.Resolve<IMvxMessenger>();
        public IMvxMessenger Messenger
        {
            get
            {
                return _messenger;
            }
            set
            {
                _messenger = value;
            }
        }

        public BaseViewModel(IMvxMessenger messenger)
        {
            Messenger = messenger;
        }

        protected BaseViewModel() { }
    }
}
