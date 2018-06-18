using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Core.Storage
{
    public interface IConnection : IDisposable
    {
        string TypeConnection { get; }

        string ConnectionString { get; set; }

        IDbConnection DataProvider { get;  }

        void Open();

        void Close();
    }
}
