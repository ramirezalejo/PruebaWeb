using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace Core.Storage.Reflection
{
    public class Column<tEntity>
        where tEntity : BaseEntity
    {
        private Table<tEntity> table; 

        public Column(Table<tEntity> table)
        {
            this.table = table;
        }

        public Dictionary<string, object> GetPrimaryKeys()
        {
            Dictionary<string, object> dicPrimaryKeys = new Dictionary<string, object>();
            Type typeTable = table.GetEntityType();
            foreach (PropertyInfo property in typeTable.GetProperties())
            {
                ColumnAttribute columnAttribute = property.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute;
                if(columnAttribute != null)
                {
                    if(columnAttribute.IsPrimaryKey)
                    {
                        dicPrimaryKeys.Add(property.Name, property.GetValue(table.GetCurrentEntity()));
                    }
                }
            }
            return dicPrimaryKeys;
        }

        
    }




}

