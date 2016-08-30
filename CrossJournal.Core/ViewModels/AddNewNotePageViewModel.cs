using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace CrossJournal.Core.ViewModels
{
    public class AddNewNotePageViewModel : BaseViewModel
    {
        private IRecordingsManager _recordingsManager;
        
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

        public AddNewNotePageViewModel(IRecordingsManager recordingsManager)
        {
            _recordingsManager = recordingsManager;
            _recordingsManager.GetCurrentVersion();
        }


        private ICommand _okClickCommand;
        public ICommand OkClickCommand
        {
            get
            {
                _okClickCommand = new MvxCommand(() => OnDoneClick());
                return _okClickCommand;
            }
        }


        public void OnDoneClick()
        {
            _recordingsManager.Create(TextBoxContent);
            Messenger.Publish(new CollectionChangedMessage(this));
            Close(this);
        }
    }
}