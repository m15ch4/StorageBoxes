using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface IOptionValueService
    {
        BindableCollection<OptionValue> GetAllForOption(Option option);
    }
}
