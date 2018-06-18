using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Reflection
{
    public static class HelperDictionary
    {


        private static void LoadValues<tEntity>(Table<tEntity> table, out Dictionary<string, object> primaryKeys, out string key)
            where tEntity : BaseEntity
        {
            primaryKeys = table.GetColumn().GetPrimaryKeys();
            key = Newtonsoft.Json.JsonConvert.SerializeObject(primaryKeys);
        }

        public static void Load<tEntity>(this Dictionary<string, tEntity> dictionary, List<tEntity> entityList)
            where tEntity : BaseEntity
        {
            foreach (tEntity item in entityList)
            {
                tEntity tempItem = item;
                dictionary.AddOrUpdate(ref tempItem);
            }
        }


        public static void AddOrUpdate<tEntity>(this Dictionary<string, tEntity> dictionary, ref tEntity entity)
            where tEntity : BaseEntity
        {
            Table<tEntity> tableItem = new Table<tEntity>(entity);
            Dictionary<string, object> primaryKeys;
            string key;
            LoadValues(tableItem, out primaryKeys, out key);
            if (dictionary.ExistPrimaryKey(entity))
            {
                dictionary[key] = entity;
            }
            else
            {
                dictionary.Add(key, entity);
            }
        }

        public static bool ExistPrimaryKey<tEntity>(this Dictionary<string, tEntity> dictionary, tEntity entity)
            where tEntity : BaseEntity
        {
            Table<tEntity> tableItem = new Table<tEntity>(entity);
            Dictionary<string, object> primaryKeys;
            string key;
            LoadValues(tableItem, out primaryKeys, out key);
            if (dictionary.ContainsKey(key))
                return true;
            else
                return false;
        }

    }
}
