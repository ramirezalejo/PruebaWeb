using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Storage.Reflection;
using System.IO;
namespace Core.Storage.Implement
{
    public class FileCommand : ICommand
    {

        FileConnection _connection;


        public FileCommand(FileConnection connection)
        {
            _connection = connection;
        }


        public bool DeleteEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            return true;
        }

        public List<tEntity> GetEntities<tEntity>(Func<tEntity, bool> wherePredicate) where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>();

            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                return _connection.Serializer.DeserializeList<tEntity>(readerString).Where(wherePredicate).ToList();
            }
        }

        public List<tEntity> GetEntities<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy) where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>();
            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                return _connection.Serializer.DeserializeList<tEntity>(readerString).Where(wherePredicate).OrderBy(orderBy).ToList();
            }
        }

        public List<tEntity> GetEntities<tEntity>() where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>();
            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                return _connection.Serializer.DeserializeList<tEntity>(readerString);
            }
        }

        public tEntity GetEntity<tEntity>(Func<tEntity, bool> wherePredicate) where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>();
            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                return _connection.Serializer.DeserializeList<tEntity>(readerString).Where(wherePredicate).FirstOrDefault();
            }
        }

        public tEntity GetEntity<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy) where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>();
            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                return _connection.Serializer.DeserializeList<tEntity>(readerString).Where(wherePredicate).OrderBy(orderBy).FirstOrDefault();
            }
        }

        public tEntity InsertEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            Table<tEntity> table = new Table<tEntity>(entity);
            Dictionary<string, tEntity> dictionary = new Dictionary<string, tEntity>();
            using (StreamReader reader = _connection.GetReader(table.GetTableName()))
            {
                string readerString = reader.ReadToEnd();
                List<tEntity> listEntityFile = _connection.Serializer.DeserializeList<tEntity>(readerString);
                dictionary.Load(listEntityFile);
                dictionary.AddOrUpdate(ref entity);

            };
            _connection.WriteText(table.GetTableName(), _connection.Serializer.Serialize(dictionary.Select(p => p.Value).ToList()));

            return entity;
        }

        public tEntity UpdateEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            return InsertEntity(entity);
        }
    }
}
