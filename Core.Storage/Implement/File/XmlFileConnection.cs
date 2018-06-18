using Core.Storage.Implement.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement.File
{
    public class XmlFileConnection : FileConnection
    {
        public XmlFileConnection(string PathDirectory) : base(PathDirectory)
        {
        }

        public override string TypeConnection => Constants.ConnectionTypes.FileXML;

        public override string FileExtension => Constants.DefaultFileExtension.XML;

        public override IStorageSerializer Serializer => new XmlSerializer();
    }
}
