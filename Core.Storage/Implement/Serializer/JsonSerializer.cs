using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Core.Storage.Implement.Serializer
{
    public class JsonSerializer : IStorageSerializer
    {
        public tEntity Deserialize<tEntity>(string value) where tEntity : BaseEntity
        {
            return JsonConvert.DeserializeObject<tEntity>(value);
        }

        public List<tEntity> DeserializeList<tEntity>(string value) where tEntity : BaseEntity
        {
            if (string.IsNullOrEmpty(value))
                return new List<tEntity>();
            return JsonConvert.DeserializeObject<List<tEntity>>(value);
        }

        public string Serialize<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            return JsonConvert.SerializeObject(entity);
        }

        public string Serialize<tEntity>(List<tEntity> listEntity) where tEntity : BaseEntity
        {
            if (listEntity == null)
                return string.Empty;
            if (listEntity.Count == 0)
                return string.Empty;
            return JsonConvert.SerializeObject(listEntity);
        }
    }
}
