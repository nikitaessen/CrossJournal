using CrossJournal.Core.Interfaces;
using MvvmCross.Plugins.Messenger;

namespace CrossJournal.Core.Models
{
    public class RecordChangedMessage : MvxMessage
    {
        public RecordChangedMessage(object sender, string note, string date) : base(sender)
        {
            Note = note;
            Date = date;
        }

        public string Note { get; private set; }
        public string Date { get; private set; }
    }

    public class CollectionChangedMessage : MvxMessage
    {
        public CollectionChangedMessage(object sender) : base(sender)
        {
            //empty
        }
    }
}
