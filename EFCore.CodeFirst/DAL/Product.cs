using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    [Table("ProductTb", Schema = "products")]
    public class Product
    {
        public int Id { get; set; }
        [Column("name2", Order = 1)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
