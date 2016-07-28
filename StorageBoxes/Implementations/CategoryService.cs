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
    class CategoryService : ICategoryService
    {
        private SBContext _context;

        public CategoryService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public BindableCollection<Category> GetAll()
        {
            return new BindableCollection<Category>(_context.Categories);
        }
    }
}
