using System;
using System.Collections.ObjectModel;

namespace CrossJournal.Core.Models
{
    public class Record
    {
        private const string PropertyFormat = " {0} {1}";

        public string Date { set; get; }
        public string Note { set; get; }
        public ObservableCollection<ImagePath> ImagesPath = new ObservableCollection<ImagePath>();

        public override string ToString()
        {
            return String.Format(PropertyFormat, Date, Note);
        }
    }

    public class ImagePath
    {
        private const string PropertyFormat = "{0}";

        private string fullPath;
        public string FullPath
        {
            get
            {
                return this.fullPath;
            }
            set
            {
                fullPath = value;
            }
        }

        public int Id { set; get; }

        public override string ToString()
        {
            return String.Format(PropertyFormat, FullPath);
        }
    }
}
