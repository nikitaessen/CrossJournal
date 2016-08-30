using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace CrossJournal.Core.ViewModels
{
    public class EditPageViewModel : BaseViewModel
    {
        public IRecordingsManager _recordingsManager;


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
                RaisePropertyChanged(nameof(TextBoxContent));
            }
        }

        public EditPageViewModel(IRecordingsManager recordingsManager)
        {
            _recordingsManager = recordingsManager;

            _textBoxContent = _recordingsManager.CurrentItem.Note;
        }

        private ICommand _doneCommand;
        public ICommand DoneCommand
        {
            get
            {
                _doneCommand = new MvxCommand(() => OnDoneClick());
                return _doneCommand;
            }
        }

        public void OnDoneClick()
        {
            _recordingsManager.Editor(TextBoxContent);
            Messenger.Publish(new RecordChangedMessage(this, TextBoxContent, _recordingsManager.CurrentItem.Date));
            Close(this);
        }
    }
}