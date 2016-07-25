using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class OptionValue
    {
        public OptionValue()
        {

        }

        [Key]
        [Column(Order = 3)]
        public int OptionValueID { get; set; }

        [Key, ForeignKey("Option")]
        [Column(Order = 2)]
        [Index("IX_OptionValues", 2, IsUnique = true)]
        public int OptionID { get; set; }

        [Key, ForeignKey("Option")]
        [Column(Order = 1)]
        [Index("IX_OptionValues", 1, IsUnique = true)]
        public int ProductID { get; set; }

        [Index("IX_OptionValues", 3, IsUnique = true)]
        [MaxLength(200)]
        public string ValueName { get; set; }

        public Option Option { get; set; }
    }
}
