using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface IProductService
    {
        BindableCollection<Product> GetAll();

        BindableCollection<Product> GetAllByCategory(Category category);

        Product GetBySKU(ProductSKU sku);
    }
}
