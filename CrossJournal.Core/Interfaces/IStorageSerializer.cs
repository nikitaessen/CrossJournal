using System.Collections.Generic;

namespace CrossJournal.Core.Interfaces
{
    public interface IStorageSerializer<T>
    {
        string Serialize(IEnumerable<T> value);
        IEnumerable<T> Deserialize(string structure);
    }
}
