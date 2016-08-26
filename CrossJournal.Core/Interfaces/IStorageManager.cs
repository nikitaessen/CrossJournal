using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CrossJournal.Core.Models;

namespace CrossJournal.Core.Interfaces
{
    public interface IStorageManager
    {
        Task Save(ObservableCollection<Record> dataList);
        Task<ObservableCollection<Record>> Load();
    }
}
