using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement
{
    

    public abstract class DbConnection : IConnection
    {

        
        public DbConnection(IDbConnection dataProvider)
        {
            this.DataProvider = dataProvider;
            DataContext = new DataContext(dataProvider);
        }
        
        public IDbConnection DataProvider { get; }

        public DataContext DataContext { get; private set; }

        public string ConnectionString { get => DataProvider.ConnectionString; set => DataProvider.ConnectionString = value; }

        public string TypeConnection => Constants.ConnectionTypes.Db;

        public void Close()
        {
            if (DataProvider != null)
                DataProvider.Close();
            DataContext.Dispose();
            DataContext = null;
        }

        public void Dispose()
        {
            Close();
        }

        public void Open()
        {
            if (DataProvider != null)
                DataProvider.Open();
            if (DataContext == null)
                DataContext = new DataContext(DataProvider);
        }
    }
    
}
