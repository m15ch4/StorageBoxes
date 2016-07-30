using StorageBoxes.Contracts;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Implementations
{
    class BoxService : IBoxService
    {
        private SBContext _context;

        public BoxService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public Box GetOneBySKU(ProductSKU productSKU)
        {
            return _context.Boxes.Include("ProductSKU.Product").Where(b => b.ProductSKU.ProductSKUID == productSKU.ProductSKUID).SingleOrDefault();
        }

        public int GetMaxCountBySKU(ProductSKU productSKU)
        {
            return _context.Boxes.Count(b => b.ProductSKU.ProductSKUID == productSKU.ProductSKUID);
        }

        public ICollection<Box> GetBySKU(ProductSKU productSKU, int count)
        {
            return _context.Boxes.Include("ProductSKU.Product").Where(b => b.ProductSKU.ProductSKUID == productSKU.ProductSKUID).Take(count).ToList();
        }
    }
}
