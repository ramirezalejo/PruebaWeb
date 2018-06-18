using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement.DataBase
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(System.Data.SqlClient.SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

    }
}
