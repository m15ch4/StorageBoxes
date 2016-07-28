using StorageBoxes.Contracts;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using System.Collections;
using Caliburn.Micro;

namespace StorageBoxes.Implementations
{
    class SKUValueService : ISKUValueService
    {
        private SBContext _context;
        public SKUValueService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }


        public IQueryable<SKUValue> FilterByOptionValue(IQueryable<SKUValue> input, OptionValue optionValue)
        {
            return input.Where(sv => (sv.OptionValueID == optionValue.OptionValueID && sv.OptionID == optionValue.OptionID) || sv.OptionID != optionValue.OptionID);
            //return input.Where(sv => (sv.OptionValueID == optionValue.OptionValueID && sv.OptionID == optionValue.OptionID) || sv.OptionID != optionValue.OptionID);
        }

        public int FindSKUID(IQueryable<SKUValue> productSKUValues, BindableCollection<OptionValue> optionValues)
        {
            IEnumerable<int> skuIDList = productSKUValues.Select(sv => sv.ProductSKUID).ToList();
            foreach (OptionValue ov in optionValues)
            {
                IQueryable<SKUValue> optionSKUValues = productSKUValues.Where(sv => sv.OptionValueID == ov.OptionValueID);
                var temp = skuIDList.Intersect(optionSKUValues.Select(sv => sv.ProductSKUID).ToList());
                skuIDList = temp;
                foreach (int sid in temp)
                {
                    Trace.WriteLine("->" + sid);
                }
                Trace.WriteLine("--------------");
            }
            if (skuIDList.Count() == 1)
            {
                return skuIDList.First();
            }
            else return -1;
        }

        public IQueryable<SKUValue> GetAllForProduct(Product product)
        {
            return _context.SKUValues.Where(sv => sv.ProductID == product.ProductID);
        }
    }
}
