using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using System.Collections.ObjectModel;
using MvvmCross.Plugins.Messenger;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Windows.UI.Xaml.Controls;

namespace CrossJournal.Core.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        private readonly MvxSubscriptionToken _recordChangedToken;

        private IRecordingsManager _recordingsManager;

        public DetailsPageViewModel(IRecordingsManager recordingsManager)
        {
            _recordingsManager = recordingsManager;

            _textBlockContent = _recordingsManager.CurrentItem.Note;
            _date = _recordingsManager.CurrentItem.Date;
            _imagePath = _recordingsManager.CurrentItem.ImagesPath;

            //if (!Messenger.HasSubscriptionsFor<RecordChangedMessage>())
            //{
            _recordChangedToken =
                Messenger.SubscribeOnMainThread<RecordChangedMessage>(msg => UpdateProperty(msg.Date, msg.Note));
            //}
        }

        private string _textBlockContent;
        public string TextBlockContent
        {
            get
            {
                return _textBlockContent;
            }
            set
            {
                _textBlockContent = value;
                RaisePropertyChanged(() => TextBlockContent);
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RaisePropertyChanged(() => Date);
            }
        }

        private ObservableCollection<ImagePath> _imagePath;
        public ObservableCollection<ImagePath> ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                RaisePropertyChanged(() => ImagePath);
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = new MvxCommand(() => DeleteClick());
                return _deleteCommand;
            }
        }

        private ICommand _deleteImageCommand;
        public ICommand DeleteImageCommand
        {
            get
            {
                _deleteImageCommand = new MvxCommand<object>((arg) => DeleteImage(arg));
                return _deleteImageCommand;
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                _editCommand = new MvxCommand(() => EditClick());
                return _editCommand;
            }
        }

        private ICommand _attachImageCommand;
        public ICommand AttachImageCommand
        {
            get
            {
                _attachImageCommand = new MvxCommand(() => AttachClick());
                return _attachImageCommand;
            }
        }

        private ICommand _attachPhotoCommand;
        public ICommand AttachPhotoCommand
        {
            get
            {
                _attachPhotoCommand = new MvxCommand(() => CameraClick());
                return _attachPhotoCommand;
            }
        }

        private ICommand _imageClickCommand;
        public ICommand ImageClickCommand
        {
            get
            {
                _imageClickCommand = new MvxCommand<ItemClickEventArgs>((i) => ImageClick(i));
                return _imageClickCommand;
            }
        }

        public void UpdateProperty(string date, string text)
        {
            _textBlockContent = _recordingsManager.CurrentItem.Note;
            _date = _recordingsManager.CurrentItem.Date;
            RaisePropertyChanged(() => TextBlockContent);
            RaisePropertyChanged(() => Date);
        }

        public void DeleteClick()
        {
            _recordingsManager.Delete();
            Messenger.Publish(new CollectionChangedMessage(this));
            Close(this);
        }

        public void DeleteImage(object args)
        {
            var buff = args as ImagePath;
            _recordingsManager.SelectCurrentImage(buff);
            _recordingsManager.DeleteImage();
        }

        public void EditClick()
        {
            ShowViewModel<EditPageViewModel>();
        }

        //public void DeleteImageClick(ImagePath path)
        //{
        //    _recordingsManager.SelectCurrentImage(path);
        //    _recordingsManager.DeleteImage();
        //}

        public void AttachClick()
        {
            _recordingsManager.AddImage();
            _imagePath = _recordingsManager.CurrentItem.ImagesPath;
            RaisePropertyChanged(nameof(ImagePath));
        }

        public async void CameraClick()
        {
            await _recordingsManager.AddPhoto();
            _imagePath = _recordingsManager.CurrentItem.ImagesPath;
            RaisePropertyChanged(nameof(ImagePath));
        }

        public async void ImageClick(ItemClickEventArgs args)
        {
            _recordingsManager.SelectCurrentImage(args.ClickedItem as ImagePath);
        }
    }
}
