using StorageBoxes.Contracts.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBoxes.Models.Tasks;
using StorageBoxes.Models;

namespace StorageBoxes.Implementations.Tasks
{
    class TaskTypeService : ITaskTypeService
    {
        private SBContext _context;

        public TaskTypeService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public SBTaskType TTGet()
        {
            return _context.SBTaskTypes.Where(tt => tt.SBTaskTypeID == 1).FirstOrDefault();
        }
    }
}
