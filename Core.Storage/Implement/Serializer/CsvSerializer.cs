using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Core.Storage.Implement.Serializer
{
    public class CsvSerializer : IStorageSerializer
    {
        public tEntity Deserialize<tEntity>(string value) where tEntity : BaseEntity
        {
            using (TextReader reader = new StringReader(value))
            {
                using (CsvHelper.CsvReader readerCsv = new CsvHelper.CsvReader(reader))
                {
                    return readerCsv.GetRecord<tEntity>();
                }
            }
        }

        public List<tEntity> DeserializeList<tEntity>(string value) where tEntity : BaseEntity
        {
            using (TextReader reader = new StringReader(value))
            {
                using (CsvHelper.CsvReader readerCsv = new CsvHelper.CsvReader(reader))
                {
                    return readerCsv.GetRecords<tEntity>().ToList();
                }
            }
        }

        public string Serialize<tEntity>(tEntity entity) where tEntity : BaseEntity
        {
            using (TextWriter writer = new StringWriter())
            {
                using (CsvHelper.CsvWriter writerCsv = new CsvHelper.CsvWriter(writer))
                {
                    writerCsv.WriteRecord(entity);
                }
                return writer.ToString();
            }
            
        }

        public string Serialize<tEntity>(List<tEntity> listEntity) where tEntity : BaseEntity
        {
            using (TextWriter writer = new StringWriter())
            {
                using (CsvHelper.CsvWriter writerCsv = new CsvHelper.CsvWriter(writer))
                {
                    writerCsv.WriteRecords(listEntity);
                }
                return writer.ToString();
            }
        }
    }
}
