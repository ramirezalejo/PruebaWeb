using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage
{
    public interface IStorageSerializer
    {
        string Serialize<tEntity>(tEntity entity)
            where tEntity : BaseEntity;

        tEntity Deserialize<tEntity>(string value)
            where tEntity : BaseEntity;

        string Serialize<tEntity>(List<tEntity> listEntity)
            where tEntity : BaseEntity;

        List<tEntity> DeserializeList<tEntity>(string value)
            where tEntity : BaseEntity;
    }
}
