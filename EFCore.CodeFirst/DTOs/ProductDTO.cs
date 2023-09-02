using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(9, 2)]
        public decimal Price { get; set; }
        [Precision(9, 2)]
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }
    }
}
