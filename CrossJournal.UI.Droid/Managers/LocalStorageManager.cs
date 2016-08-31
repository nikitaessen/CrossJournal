using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using CrossJournal.UI.Droid.Managers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
//using Xamarin.Forms;
using System.IO;

//[assembly: Dependency(typeof(LocalStorageManager))]
namespace CrossJournal.UI.Droid.Managers
{
    public class LocalStorageManager : IStorageManager
    {
        private readonly IStorageSerializer<Record> _serializer;
        const string Filename = "storedgarbage.xml";

        public LocalStorageManager(IStorageSerializer<Record> storageSerializer)
        {
            _serializer = storageSerializer;
        }

        
        public async Task Save(ObservableCollection<Record> dataList)
        {
            var localData = _serializer.Serialize(dataList);
            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = Path.Combine(path, Filename);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(localData);
            }
        }

        public async Task<ObservableCollection<Record>> Load()
        {
            var loadedList = new ObservableCollection<Record>();
            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = Path.Combine(path, Filename);

            if (File.Exists(filePath))
            {
                var content = File.ReadAllText(filePath);
                loadedList = new ObservableCollection<Record>(_serializer.Deserialize(content));
            }

            return loadedList;
        }
    }
}