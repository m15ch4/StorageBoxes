using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class WishListItem
    {
        private int _count;
        private ProductSKU _productSKU;

        public WishListItem(ProductSKU productSKU, int count)
        {
            ProductSKU = productSKU;
            Count = count;
        }
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public ProductSKU ProductSKU
        {
            get { return _productSKU; }
            set
            {
                _productSKU = value;
            }
        }
    }
}