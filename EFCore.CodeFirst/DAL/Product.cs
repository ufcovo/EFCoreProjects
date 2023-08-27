using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class Product
    { 
        public int Id { get; set; }
        //[Unicode(false)] // varchar olarak gelecek nvarchar olarak değil
        public string Name { get; set; }
        //[Column(TypeName = "nvarchar(200)")]
        public string Url { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //[NotMapped]
        public int Barcode { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }
    }
}
