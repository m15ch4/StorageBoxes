using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class SKUValue
    {
        public SKUValue()
        {

        }

        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductSKUID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int OptionID { get; set; }

        public int OptionValueID { get; set; }

        public ProductSKU ProductSKU { get; set; }
        public Option Option { get; set; }
        public OptionValue OptionValue { get; set; }
    }
}
