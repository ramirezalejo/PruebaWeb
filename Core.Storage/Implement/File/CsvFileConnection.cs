using Core.Storage.Implement.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement.File
{
    public class CsvFileConnection : FileConnection
    {
        public CsvFileConnection(string PathDirectory) : base(PathDirectory)
        {
        }

        public override string TypeConnection => Constants.ConnectionTypes.FileCSV;

        public override string FileExtension => Constants.DefaultFileExtension.CSV;

        public override IStorageSerializer Serializer => new CsvSerializer();
    }
}
