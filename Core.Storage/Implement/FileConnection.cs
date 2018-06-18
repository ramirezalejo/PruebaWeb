using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core.Storage.Implement
{
    public abstract class FileConnection : IConnection
    {

        public abstract string TypeConnection { get; }

        public abstract string FileExtension { get; }

        public abstract IStorageSerializer Serializer { get;  }

        public FileConnection(string PathDirectory)
        {
            ConnectionString = PathDirectory;
            ValidateDirectory();
        }
        

        private void ValidateFile(string PathFile)
        {
            if (!System.IO.File.Exists(PathFile))
            {
                System.IO.File.Create(PathFile).Dispose();
            }
        }


        public StreamReader GetReader(string Name)
        {
            Name = string.Format("{0}.{1}", Name, FileExtension);
            string PathFile = Path.Combine(ConnectionString, Name);
            ValidateFile(PathFile);
            return new StreamReader(PathFile);
        }


        public StreamWriter GetWriter(string Name)
        {
            Name = string.Format("{0}.{1}", Name, FileExtension);
            string PathFile = Path.Combine(ConnectionString, Name);
            ValidateFile(PathFile);
            return new StreamWriter(PathFile);
        }

        public void WriteText(string Name, string Value)
        {
            Name = string.Format("{0}.{1}", Name, FileExtension);
            string PathFile = Path.Combine(ConnectionString, Name);
            ValidateFile(PathFile);
            System.IO.File.WriteAllText(PathFile, Value);
        }

        protected void ValidateDirectory()
        {
            if (!Directory.Exists(ConnectionString))
                Directory.CreateDirectory(ConnectionString);
        }

        

        public  string ConnectionString { get;  set; }

        [Obsolete("In file connection, is not necesary", true)]
        public IDbConnection DataProvider => throw new NotImplementedException();

        [Obsolete("In File connection, is not necesary", true)]
        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        [Obsolete("In file connection, is not necesary", true)]
        public virtual void Open()
        {
            throw new NotImplementedException();
        }
    }
}
