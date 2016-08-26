using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CrossJournal.Core.Managers
{
    public class RecordingsManager : IRecordingsManager
    {
        private readonly IStorageManager _localStorageManager;
        private IAttachmentManager _attachmentManager;

        public RecordingsManager(IStorageManager localStorageManager, IAttachmentManager attachmentManager)
        {
            _localStorageManager = localStorageManager;
            _attachmentManager = attachmentManager;
        }

        private ObservableCollection<Record> _dataList = new ObservableCollection<Record>();
        public ObservableCollection<Record> DataList
        {
            get
            {
                return this._dataList;
            }
            set
            {
                _dataList = value;
            }
        }

        private Record currentItem;
        public Record CurrentItem
        {
            get
            {
                return this.currentItem;
            }
            set
            {
                currentItem = value;
            }
        }

        private ImagePath currentImage;
        public ImagePath CurrentImage
        {
            get
            {
                return this.currentImage;
            }
            set
            {
                currentImage = value;
            }
        }


        public async Task<ObservableCollection<Record>> GetCurrentVersion()
        {
            DataList = await _localStorageManager.Load();

            return DataList;
        }

        public Record SelectCurrentItem(Record item)
        {
            CurrentItem = DataList.FirstOrDefault(f => f.Date == item.Date);

            return CurrentItem;
        }

        public ImagePath SelectCurrentImage(ImagePath image)
        {
            CurrentImage = CurrentItem.ImagesPath.FirstOrDefault(f => f.Id == image.Id);

            return CurrentImage;
        }

        public async Task<ObservableCollection<Record>> Create(string noteContent)
        {
            if (!string.IsNullOrEmpty(noteContent))
            {
                Record record = new Record() { Note = noteContent, Date = DateTime.Now.ToString() };
                DataList.Add(record);
                await _localStorageManager.Save(DataList);
            }
            return DataList;
        }

        public async Task<ObservableCollection<Record>> Delete()
        {
            DataList.Remove(CurrentItem);
            await _localStorageManager.Save(DataList);

            return DataList;
        }
        public async Task<ObservableCollection<Record>> DeleteImage()
        {
            CurrentItem.ImagesPath.Remove(CurrentImage);
            await _localStorageManager.Save(DataList);

            return DataList;
        }

        public async Task<ObservableCollection<Record>> Editor(string note)
        {
            if (CurrentItem.Note != note)
            {
                DataList.Remove(CurrentItem);
                Record record = new Record() { Note = note, Date = DateTime.Now.ToString() };
                DataList.Add(record);
                var currentTime = record.Date;
                foreach (Record item in DataList)
                {
                    if (currentTime == item.Date)
                    {
                        CurrentItem = item;
                    }
                }
                await _localStorageManager.Save(DataList);
            }
            return DataList;
        }

        public async Task<ObservableCollection<Record>> AddImage()
        {
            var buff = await _attachmentManager.AttachImage();
            if (buff != null)
            {
                CurrentItem.ImagesPath.Add(buff);
                await _localStorageManager.Save(DataList);
            }
            return DataList;
        }

        public async Task<ObservableCollection<Record>> AddPhoto()
        {
            var buff = await _attachmentManager.AttachPhoto();
            if (buff != null)
            {
                CurrentItem.ImagesPath.Add(buff);
                await _localStorageManager.Save(DataList);
            }
            return DataList;
        }
    }
}