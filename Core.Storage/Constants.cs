using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage
{
    public static class Constants
    {
        public static class ConnectionTypes
        {
            public static readonly string InMemory = "In Memory Connection";

            public static readonly string File = "File Connection";
            public static readonly string Db = "DataBase Connection";
            public static readonly string FileCSV = "File CSV Connection";
            public static readonly string FileXML = "File XML Connection";
            public static readonly string FileJSON = "File JSON Connection";
        }


        public static class DefaultFileExtension
        {
            public static readonly string CSV = "csv";
            public static readonly string XML = "xml";
            public static readonly string JSON = "json";
        }
    }
}
