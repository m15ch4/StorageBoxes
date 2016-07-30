using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts
{
    public interface IBoxService
    {
        Box GetOneBySKU(ProductSKU productSKU);

        ICollection<Box> GetBySKU(ProductSKU productSKU, int count);
        int GetMaxCountBySKU(ProductSKU productSKU);
    }
}
