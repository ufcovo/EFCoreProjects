using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProjects.DatabaseFirst.DAL
{
    public class Product
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public decimal PRICE { get; set; }
    }
}
