using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface IOptionService
    {
        BindableCollection<Option> GetAllByProduct(Product product);
    }
}
