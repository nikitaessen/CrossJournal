using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace CrossJournal.Core.ViewModels
{
    public class AddNewNotePageViewModel : BaseViewModel
    {
        private IRecordingsManager _recordingsManager;
        private IAttachmentManager _attachmentManager;

        private string _textBoxContent;
        public string TextBoxContent
        {
            get
            {
                return _textBoxContent;
            }
            set
            {
                _textBoxContent = value;
                RaisePropertyChanged(()=>TextBoxContent);
            }
        }

        public AddNewNotePageViewModel(IRecordingsManager recordingsManager, IAttachmentManager attachmentManager)
        {
            _recordingsManager = recordingsManager;
            _recordingsManager.GetCurrentVersion();
        }

        private ICommand _onDoneClick;
        public ICommand OnDoneClick
        {
            get
            {
                _onDoneClick = new MvxCommand(() => CreateNote());
                return _onDoneClick;
            }
        }

        public void CreateNote()
        {
            _recordingsManager.Create(TextBoxContent);
            Messenger.Publish(new CollectionChangedMessage(this));
            Close(this);
        }
    }
}