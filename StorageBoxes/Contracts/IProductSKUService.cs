using Caliburn.Micro;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface IProductSKUService
    {
        BindableCollection<ProductSKU> GetAll();

        BindableCollection<ProductSKU> GetAllForProduct(Product product);

        ProductSKU GetByID(int id);
    }
}
