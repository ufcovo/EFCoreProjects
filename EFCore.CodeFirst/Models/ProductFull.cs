using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.Models
{
    public class ProductFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

    }
}
