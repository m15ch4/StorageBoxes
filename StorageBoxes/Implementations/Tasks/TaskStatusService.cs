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
    class TaskStatusService : ITaskStatusService
    {
        private SBContext _context;

        public TaskStatusService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public SBTaskStatus TSCompleted()
        {
            return _context.SBTaskStatuses.Where(ts => ts.SBTaskStatusID == 3).SingleOrDefault();
        }

        public SBTaskStatus TSFailed()
        {
            return _context.SBTaskStatuses.Where(ts => ts.SBTaskStatusID == 4).SingleOrDefault();
        }

        public SBTaskStatus TSQueued()
        {
            return _context.SBTaskStatuses.Where(ts => ts.SBTaskStatusID == 1).SingleOrDefault();
        }

        public SBTaskStatus TSRunning()
        {
            return _context.SBTaskStatuses.Where(ts => ts.SBTaskStatusID == 2).SingleOrDefault();
        }
    }
}
