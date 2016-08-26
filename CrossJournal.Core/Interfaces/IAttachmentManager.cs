using CrossJournal.Core.Models;
using System.Threading.Tasks;

namespace CrossJournal.Core.Interfaces
{
    public interface IAttachmentManager
    {
        Task<ImagePath> AttachImage();
        Task<ImagePath> AttachPhoto();
    }
}
