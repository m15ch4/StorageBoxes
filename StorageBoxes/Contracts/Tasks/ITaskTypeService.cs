using StorageBoxes.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts.Tasks
{
    public interface ITaskTypeService
    {
        SBTaskType TTGet();
    }
}
