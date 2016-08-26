using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace CrossJournal.UI.UWP.Managers
{
    public class AttachmentManager : IAttachmentManager
    {
        private Random idGenerator = new Random();

        static async Task<bool> DoesFileExistAsync(string fileName)
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ImagePath> AttachImage()
        {
            ImagePath path = null;

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            IReadOnlyList<StorageFile> files = await openPicker.PickMultipleFilesAsync();
            string fileName = string.Empty;

            if (files.Count > 0)
            {
                foreach (StorageFile file in files)
                {
                    fileName = file.Name;
                    await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.GenerateUniqueName);

                    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                    bool result = await DoesFileExistAsync(fileName);
                    if (result)
                    {
                        StorageFile localFile = await localFolder.GetFileAsync(fileName);
                        path = new ImagePath() { FullPath = localFile.Path, Id = idGenerator.Next() };
                    }
                }
            }
            return path;
        }

        public async Task<ImagePath> AttachPhoto()
        {
            ImagePath path = null;

            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            string fileName = string.Empty;

            if (photo != null)
            {
                fileName = photo.Name;
                await photo.CopyAsync(ApplicationData.Current.LocalFolder, photo.Name, NameCollisionOption.GenerateUniqueName);
                using (IRandomAccessStream fileStream = await photo.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();

                    await bitmapImage.SetSourceAsync(fileStream);
                }
            }

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            bool result = await DoesFileExistAsync(fileName);
            if (result)
            {
                StorageFile localFile = await localFolder.GetFileAsync(fileName);
                path = new ImagePath() { FullPath = localFile.Path, Id = idGenerator.Next() };
            }
            return path;
        }

    }
}