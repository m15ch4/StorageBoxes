using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    class Category
    {
        public Category()
        {

        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
