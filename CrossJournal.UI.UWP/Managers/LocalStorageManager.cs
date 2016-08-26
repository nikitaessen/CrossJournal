using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

namespace CrossJournal.UI.UniversalWindows.Managers
{
    public class LocalStorageManager : IStorageManager
    {
        private readonly IStorageSerializer<Record> rec;

        public LocalStorageManager(IStorageSerializer<Record> serializer)
        {
            rec = serializer;
        }

        public async Task Save(ObservableCollection<Record> dataList)
        {
            string localData = rec.Serialize(dataList);

            if (!string.IsNullOrEmpty(localData))
            {
                StorageFile localFile =
                    await ApplicationData.Current.LocalFolder.CreateFileAsync("localData.xml", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(localFile, localData);
            }
        }

        public async Task<ObservableCollection<Record>> Load()
        {
            StorageFile localFile;
            ObservableCollection<Record> loadedList = new ObservableCollection<Record>();

            localFile = await ApplicationData.Current.LocalFolder.GetFileAsync("localData.xml");

            if (localFile != null)
            {
                string localData = await FileIO.ReadTextAsync(localFile);

                loadedList = new ObservableCollection<Record>(rec.Deserialize(localData));
            }
            return loadedList;
        }
    }
}
