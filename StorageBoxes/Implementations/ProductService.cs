using StorageBoxes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using StorageBoxes.Models;
using System.Diagnostics;

namespace StorageBoxes.Implementations
{
    public class ProductService : IProductService
    {
        private SBContext _context;

        public ProductService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public BindableCollection<Product> GetAll()
        {
            return new BindableCollection<Product>(_context.Products);
        }

        public BindableCollection<Product> GetAllByCategory(Category category)
        {
            return new BindableCollection<Product>(_context.Products.Where(c => c.Category.CategoryID == category.CategoryID).ToList());
        }
    }
}
