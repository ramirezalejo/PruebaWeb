using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Implement
{

    public class DbCommand : ICommand
    {
        private DbConnection _connection;

        public DbCommand(DbConnection connection)
        {
            _connection = connection;
        }
        

        public bool DeleteEntity<tEntity>(tEntity entity)
            where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                table.DeleteOnSubmit(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in delete", ex);
            }
        }

       
        public List<tEntity> GetEntities<tEntity>(Func<tEntity, bool> wherePredicate)
            where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                return table.Where(wherePredicate).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error in getting list", ex);
            }
        }

        public List<tEntity> GetEntities<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy)
            where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                return table.Where(wherePredicate).OrderBy(orderBy).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting list ordered", ex);
            }
        }

        public List<tEntity> GetEntities<tEntity>() where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                return table.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting list", ex);
            }
        }

        public tEntity GetEntity<tEntity>(Func<tEntity, bool> wherePredicate)
            where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                return table.FirstOrDefault(wherePredicate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in get entity", ex);
            }
        }

        public tEntity GetEntity<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy)
            where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                return table.OrderBy(orderBy).FirstOrDefault(wherePredicate);
            }
            catch (Exception ex)
            {

                throw new Exception("Error in get entity ordered");
            }
        }

        public tEntity InsertEntity<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            try
            {
                var table = _connection.DataContext.GetTable<tEntity>();
                table.InsertOnSubmit(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception("Error insert entity", ex);
            }
        }

        public tEntity UpdateEntity<tEntity>(tEntity entity)
            where tEntity : BaseEntity
        {

            try
            {
                _connection.DataContext.Refresh(RefreshMode.KeepCurrentValues, entity);
                _connection.DataContext.SubmitChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error update entity", ex);
            }
        }
    }
}
