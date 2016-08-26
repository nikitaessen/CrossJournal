using System.Collections.ObjectModel;
using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using MvvmCross.Plugins.Messenger;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Windows.UI.Xaml.Controls;

namespace CrossJournal.Core.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private MvxSubscriptionToken _collectionChangedToken;
        private IRecordingsManager _recordingsManager;
        public IRecordingsManager RecordingsManager
        {
            get
            {
                return _recordingsManager;
            }
            set
            {
                SetProperty(ref _recordingsManager, value);
                //_recordingsManager = value;
                //RaisePropertyChanged(()=>RecordingsManager);
            }
        }

        private ObservableCollection<Record> _localCollection = new ObservableCollection<Record>();
        public ObservableCollection<Record> LocalCollection
        {
            get
            {
                return this._localCollection;
            }
            set
            {
                _localCollection = value;
                RaisePropertyChanged(nameof(LocalCollection));
            }
        }

        public MainPageViewModel(IRecordingsManager recordingsManager)
        {
            _recordingsManager = recordingsManager;
            _recordingsManager.GetCurrentVersion();
            LocalCollection = _recordingsManager.DataList;

            _collectionChangedToken =
                   Messenger.SubscribeOnMainThread<CollectionChangedMessage>(msg => UpdateProperty());
        }

        public void UpdateProperty()
        {
            LocalCollection = RecordingsManager.DataList;
            RaisePropertyChanged(nameof(LocalCollection));
        }

        private ICommand _addClickCommand;
        public ICommand AddClickCommand
        {
            get
            {
                _addClickCommand = new MvxCommand(() => ShowViewModel<AddNewNotePageViewModel>());
                return _addClickCommand;
            }
        }

        private void OnItemClicked(ItemClickEventArgs args)
        {
            var item = args.ClickedItem as Record;
            RecordingsManager.SelectCurrentItem(item);
            ShowViewModel<DetailsPageViewModel>();
        }

        private ICommand _itemClickCommand;
        public ICommand ItemClickCommand
        {
            get
            {
                _itemClickCommand = new MvxCommand<ItemClickEventArgs>((arg) => OnItemClicked(arg));
                return _itemClickCommand;
            }
        }

        public void GoToDetails(Record item)
        {
            RecordingsManager.SelectCurrentItem(item);
            ShowViewModel<DetailsPageViewModel>();
        }
    }
}
