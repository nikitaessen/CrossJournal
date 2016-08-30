using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System.Windows.Input;

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

        private ICommand _deleteClickCommand;
        public ICommand DeleteClickCommand
        {
            get
            {
                _deleteClickCommand = new MvxCommand(() => DeleteClick());
                return _deleteClickCommand;
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
                _editCommand = new MvxCommand(() => ShowViewModel<EditPageViewModel>());
                return _editCommand;
            }
        }

        private ICommand _attachImageCommand;
        public ICommand AttachImageCommand
        {
            get
            {
                _attachImageCommand = new MvxCommand(() => AttachImage());
                return _attachImageCommand;
            }
        }

        private ICommand _attachPhotoCommand;
        public ICommand AttachPhotoCommand
        {
            get
            {
                _attachPhotoCommand = new MvxCommand(() => AttachPhoto());
                return _attachPhotoCommand;
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
            _recordingsManager.SelectCurrentImage(args as ImagePath);
            _recordingsManager.DeleteImage();
        }

        public void DeleteImageClick(ImagePath path)
        {
            _recordingsManager.SelectCurrentImage(path);
            _recordingsManager.DeleteImage();
        }

        public void AttachImage()
        {
            _recordingsManager.AddImage();
        }

        public void AttachPhoto()
        {
            _recordingsManager.AddPhoto();
        }
    }
}
