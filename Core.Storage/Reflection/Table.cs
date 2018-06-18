using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq.Mapping;

namespace Core.Storage.Reflection
{
    public class Table<tEntity>
        where tEntity : BaseEntity
    {
        private tEntity _currentEntity;
        private Type _currentType;

        public Table(tEntity entity)
        {
            _currentEntity = entity;
            _currentType = typeof(tEntity);
        }

        public Type GetEntityType()
        {
            return _currentType;
        }

        public tEntity GetCurrentEntity()
        {
            return _currentEntity;
        }

        public Table()
        {
            _currentType = typeof(tEntity);
            _currentEntity = Activator.CreateInstance<tEntity>();
        }


        public string GetTableName()
        {
            TableAttribute tableAttribute = GetTableAttribute();
            return tableAttribute.Name;
        }

        public Column<tEntity> GetColumn()
        {
            return new Column<tEntity>(this);
        }


        private TableAttribute GetTableAttribute()
        {
            TableAttribute tableAttribute = (TableAttribute)_currentType.GetCustomAttribute(typeof(TableAttribute), true);
            if (tableAttribute == null)
                throw new Exception("Not exists table attribute in entity");
            return tableAttribute;
        }
    }
}
