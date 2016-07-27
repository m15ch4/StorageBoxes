using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class Option
    {
        public Option()
        {

        }

        [Key, ForeignKey("Product")]
        [Column(Order = 1)]
        [Index("IX_Options", 2, IsUnique = true)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OptionID { get; set; }

        [Index("IX_Options", 1, IsUnique = true)]
        [MaxLength(200)]
        public string OptionName { get; set; }

        

        public Product Product { get; set; }
        public ICollection<OptionValue> OptionValues { get; set; }
    }
}
