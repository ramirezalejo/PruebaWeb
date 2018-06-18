using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage
{
    public interface ICommand
    {

        List<tEntity> GetEntities<tEntity>()
            where tEntity : BaseEntity;

        List<tEntity> GetEntities<tEntity>(Func<tEntity, bool> wherePredicate)
            where tEntity : BaseEntity;

        List<tEntity> GetEntities<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy)
            where tEntity : BaseEntity;

        tEntity GetEntity<tEntity>(Func<tEntity, bool> wherePredicate)
            where tEntity : BaseEntity;

        tEntity GetEntity<tEntity, tKey>(Func<tEntity, bool> wherePredicate, Func<tEntity, tKey> orderBy)
            where tEntity : BaseEntity;

        tEntity UpdateEntity<tEntity>(tEntity entity)
            where tEntity : BaseEntity;


        bool DeleteEntity<tEntity>(tEntity entity)
            where tEntity : BaseEntity;

        tEntity InsertEntity<tEntity>(tEntity entity)
            where tEntity : BaseEntity;
        
    }
}
