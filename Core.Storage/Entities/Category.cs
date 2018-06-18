using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Storage.Entities
{
    [Table(Name = "Inventory.Category")]
    public class Category : BaseEntity
    {
        [Column(Name = "Id", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public int Id { get; set; }

        [Column(Name = "Name", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public string Name { get; set; }
    }
}
