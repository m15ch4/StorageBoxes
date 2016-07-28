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
    class OptionValueService : IOptionValueService
    {
        private SBContext _context;

        public OptionValueService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public BindableCollection<OptionValue> GetAllForOption(Option option)
        {
            return new BindableCollection<OptionValue>(_context.OptionValues.Where(ov => ov.OptionID == option.OptionID).ToList());
        }
    }
}
