using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.AppLogic
{
    class ProductsController
    {
        private SBContext _context;
        public ProductsController()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        // GetCategories
        public BindableCollection<Category> GetCategories()
        {
            return new BindableCollection<Category>(_context.Categories);
        }

        // GetProducts
        public BindableCollection<Product> GetProducts(Category category = null)
        {
            if (category == null)
            {
                return new BindableCollection<Product>(_context.Products.Include("Options.OptionValues"));
            }
            else
            {
                return new BindableCollection<Product>(_context.Products.Where(pr => pr.Category.CategoryID == category.CategoryID).ToList());
            }
        }

        // Get Product Skus
        public BindableCollection<ProductSKU> GetProductSKUs(Product product = null)
        {
            if (product == null)
            {
                return new BindableCollection<ProductSKU>(_context.ProductSKUS.Include("SKUValues.OptionValue").Include("SKUValues.Option"));
            }
            else
            {
                return new BindableCollection<ProductSKU>(_context.ProductSKUS.Where(sku => sku.Product.ProductID == product.ProductID).Include("SKUValues.OptionValue").Include("SKUValues.Option").ToList());
            }
        }

        public BindableCollection<OptionValue> GetOptionValues(Option option)
        {
            //return new BindableCollection<OptionValue>(_context.OptionValues.Where(op => op.OptionID == option.OptionID).ToList());
            var ls = _context.OptionValues;
            return new BindableCollection<OptionValue>(_context.OptionValues);
        }
    }
}
