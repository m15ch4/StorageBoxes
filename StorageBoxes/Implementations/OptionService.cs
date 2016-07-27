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
    class OptionService : IOptionService
    {
        private SBContext _context;

        public OptionService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }
        public BindableCollection<Option> GetAllByProduct(Product product)
        {
            return new BindableCollection<Option>(_context.Options.Where(o => o.ProductID == product.ProductID).ToList());
        }
    }
}
