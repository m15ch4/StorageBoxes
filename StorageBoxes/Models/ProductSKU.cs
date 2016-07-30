using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class ProductSKU
    {
        public ProductSKU()
        {

        }

        [Key]
        [Column(Order = 2)]
        [Index(IsUnique = true)]
        public int ProductSKUID { get; set; }

        [Key, ForeignKey("Product")]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        public string Sku { get; set; }

        public string Price { get; set; }

        public Product Product { get; set; }
        public ICollection<SKUValue> SKUValues { get; set; }
        public ICollection<Box> Boxes { get; set; }
    }
}
