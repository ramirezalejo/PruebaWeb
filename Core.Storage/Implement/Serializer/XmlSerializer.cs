using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Core.Storage.Implement.Serializer
{
    public class XmlSerializer : IStorageSerializer
    {
        public tEntity Deserialize<tEntity>(string value) where tEntity : BaseEntity
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(tEntity));
            using (TextReader reader = new StringReader(value))
            {
                return (tEntity)serializer.Deserialize(reader);
            }
        }

        public List<tEntity> DeserializeList<tEntity>(string value) where tEntity : BaseEntity
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<tEntity>));
            using (TextReader reader = new StringReader(value))
            {
                return (List<tEntity>)serializer.Deserialize(reader);
            }
        }

        public string Serialize<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(tEntity));
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, entity);
                return writer.ToString();
            }
        }

        public string Serialize<tEntity>(List<tEntity> listEntity) where tEntity : BaseEntity
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<tEntity>));
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, listEntity);
                return writer.ToString();
            }
        }
    }
}
