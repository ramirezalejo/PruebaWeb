using Core.Storage.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement
{
    public class InMemoryCommand : ICommand
    {
        InMemoryConnection connection;

        public InMemoryCommand(InMemoryConnection connection)
        {
            this.connection = connection;
        }

        public bool DeleteEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>(entity);
                string tableName = table.GetTableName();
                List<tEntity> listEntity = this.connection.Get<tEntity>(tableName);
                listEntity.RemoveAt(listEntity.IndexOf(entity));
                this.connection.AddOrUpdate(listEntity, tableName);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in delete", ex);
            }
        }

        public List<tEntity> GetEntities<tEntity>() where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                return this.connection.Get<tEntity>(tableName); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting list", ex);
            }
        }

        public List<tEntity> GetEntities<tEntity>(Func<tEntity, bool> wherePredicate) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                return this.connection.Get<tEntity>(tableName).Where(wherePredicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting list", ex);
            }
        }

        public List<tEntity> GetEntities<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                return this.connection.Get<tEntity>(tableName).Where(wherePredicate).OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting list", ex);
            }
        }

        public tEntity GetEntity<tEntity>(Func<tEntity, bool> wherePredicate) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                return this.connection.Get<tEntity>(tableName).FirstOrDefault(wherePredicate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in get entity", ex);
            }
        }

        public tEntity GetEntity<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                return this.connection.Get<tEntity>(tableName).OrderBy(orderBy).FirstOrDefault(wherePredicate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in get entity", ex);
            }
        }

        public tEntity InsertEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            try
            {
                Table<tEntity> table = new Table<tEntity>();
                string tableName = table.GetTableName();
                Dictionary<string, tEntity> dictionary = new Dictionary<string, tEntity>();
                List<tEntity> listEntity = this.connection.Get<tEntity>(tableName);

                dictionary.Load(listEntity);
                dictionary.AddOrUpdate(ref entity);
                listEntity = dictionary.Select(p => p.Value).ToList();
                this.connection.AddOrUpdate<tEntity>(listEntity, tableName);
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception("Error insert entity", ex);
            }
        }

        public tEntity UpdateEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            try
            {
                return InsertEntity(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error update entity", ex);
            }
        }
    }
}
