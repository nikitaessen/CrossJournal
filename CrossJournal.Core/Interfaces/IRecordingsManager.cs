using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CrossJournal.Core.Models;

namespace CrossJournal.Core.Interfaces
{
    public interface IRecordingsManager
    {
        Record CurrentItem { get; set; }
        ImagePath CurrentImage { get; set; }
        ObservableCollection<Record> DataList { get; set; }
        Task<ObservableCollection<Record>> GetCurrentVersion();
        Task<ObservableCollection<Record>> Create(string noteContent);
        Task<ObservableCollection<Record>> Delete();
        Task<ObservableCollection<Record>> Editor(string note);
        Record SelectCurrentItem(Record item);
        ImagePath SelectCurrentImage(ImagePath image);
        Task<ObservableCollection<Record>> DeleteImage();
        Task<ObservableCollection<Record>> AddImage();
        Task<ObservableCollection<Record>> AddPhoto();
    }
}
