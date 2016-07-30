using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Messages
{
    public class CountMessage
    {
        public CountMessage(int count)
        {
            Count = count;
        }

        public int Count { get; private set; }
    }
}
