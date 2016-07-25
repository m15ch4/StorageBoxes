using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class SBContext : DbContext
    {
        public SBContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }
        public DbSet<ProductSKU> ProductSKUS { get; set; }
        public DbSet<SKUValue> SKUValues { get; set; }
    }

}
