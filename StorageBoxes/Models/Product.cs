using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class Product
    {
        public Product()
        {

        }

        public int ProductID { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(200)]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public Category Category { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<ProductSKU> ProductSKUS { get; set; }
    }
}
