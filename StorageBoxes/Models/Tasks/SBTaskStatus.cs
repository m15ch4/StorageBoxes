using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models.Tasks
{
    public class SBTaskStatus
    {
        public int SBTaskStatusID { get; set; }
        public string SBTaskStatusName { get; set; }

        public static implicit operator SBTaskStatus(SBTaskType v)
        {
            throw new NotImplementedException();
        }
    }
}
