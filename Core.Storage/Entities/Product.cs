using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Storage.Entities
{
    [Table(Name = "Inventory.Product")]
    public class Product : BaseEntity
    {
        [Display(Name = "Code")]
        [Column(IsPrimaryKey = true, Name = "Code", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public int Code { get; set; }

        [Display(Name = "Id Category")]
        [Column(Name = "IdCategory", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public int IdCategory { get; set; }

        [Display(Name = "Name")]
        [Column(Name = "Name", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Column(Name = "Price", DbType = "decimal", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public decimal Price { get; set; }

        [Display(Name = "Amount")]
        [Column(Name = "Amount", UpdateCheck = UpdateCheck.Always, IsVersion = false)]
        public int Amount { get; set; }

    }
}
