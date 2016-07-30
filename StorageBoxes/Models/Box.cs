using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class Box
    {
        public Box()
        {

        }

        public int BoxID { get; set; }
        public double AddressRow { get; set; }
        public double AddressCol { get; set; }
 
        public ProductSKU ProductSKU { get; set; }

    }
}
