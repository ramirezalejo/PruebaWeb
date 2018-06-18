using Core.Storage.Implement.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement.File
{
    public class JsonFileConnection : FileConnection
    {
        public JsonFileConnection(string PathDirectory) : base(PathDirectory)
        {

        }

        public override string TypeConnection => Constants.ConnectionTypes.FileJSON;

        public override string FileExtension => Constants.DefaultFileExtension.JSON;

        public override IStorageSerializer Serializer => new JsonSerializer();
    }
}
