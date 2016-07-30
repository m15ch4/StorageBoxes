using StorageBoxes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using StorageBoxes.Models;

namespace StorageBoxes.Implementations
{
    class ProductSKUService : IProductSKUService
    {
        private SBContext _context;

        public ProductSKUService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public BindableCollection<ProductSKU> GetAll()
        {
            return new BindableCollection<ProductSKU>(_context.ProductSKUS);
        }

        public BindableCollection<ProductSKU> GetAllForProduct(Product product)
        {
            return new BindableCollection<ProductSKU>(_context.ProductSKUS.Where(ps => ps.ProductID == product.ProductID).ToList());
        }

        public ProductSKU GetByID(int id)
        {
            return _context.ProductSKUS.Include("Product").FirstOrDefault(ps => ps.ProductSKUID == id);
        }
    }
}
