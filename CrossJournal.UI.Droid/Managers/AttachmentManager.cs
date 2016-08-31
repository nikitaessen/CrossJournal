using CrossJournal.Core.Interfaces;
using CrossJournal.Core.Models;
using CrossJournal.UI.Droid.Managers;
using Java.IO;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CrossJournal.UI.Droid.Managers
{
    public class AttachmentManager : IAttachmentManager
    {
        public ObservableCollection<ImagePath> ImagesPath { get; set; }

        public static class App
        {
            public static File File;
            public static File Dir;
        }

        public AttachmentManager()
        {

        }

        public async Task<ImagePath> AttachPhoto()
        {
            ImagePath img = null;
            return img;
        }

        public async Task<ImagePath> AttachImage()
        {
            ImagePath img = null;
            return img;
        }
    }
}