using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface ISKUValueService
    {
        IQueryable<SKUValue> GetAllForProduct(Product product);
        IQueryable<SKUValue> FilterByOptionValue(IQueryable<SKUValue> input, OptionValue optionValue);
        int FindSKUID(IQueryable<SKUValue> productSKUValues, BindableCollection<OptionValue> optionValues);
    }
}
