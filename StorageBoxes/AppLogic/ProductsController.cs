using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
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
            _context = new SBContext();
        }

        public BindableCollection<Category> GetCategories()
        {
            return new BindableCollection<Category>(_context.Categories);
        }
    }
}
