using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using CrossJournal.Core.Models;
using CrossJournal.Core.Interfaces;

namespace CrossJournal.Core.Managers
{
    public class XmlStorageSerializer : IStorageSerializer<Record>
    {
        public string Serialize(IEnumerable<Record> value)
        {
            var array = value.ToArray();
            XmlSerializer serializer = new XmlSerializer(typeof(Record[]));
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                serializer.Serialize(xmlWriter, array);
            }
            return stringBuilder.ToString();
        }

        public IEnumerable<Record> Deserialize(string xml)
        {
            StringReader stringReader = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(typeof(Record[]));
            object deserialized = serializer.Deserialize(stringReader);
            var value = (Record[])deserialized;

            return value;
        }
    }
}
