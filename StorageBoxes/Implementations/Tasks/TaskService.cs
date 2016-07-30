using StorageBoxes.Contracts.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBoxes.Models.Tasks;
using StorageBoxes.Models;
using StorageBoxes.Contracts.Users;

namespace StorageBoxes.Implementations.Tasks
{
    class TaskService : ITaskService
    {
        private SBContext _context;
        private IUserService _userService;
        private IRoleService _roleService;
        private ITaskTypeService _ttService;
        private ITaskStatusService _tsService;

        public TaskService(IUserService userService, IRoleService roleService, ITaskTypeService ttService, ITaskStatusService tsService)
        {
            _userService = userService;
            _roleService = roleService;
            _ttService = ttService;
            _tsService = tsService;

            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }


        public SBTask CreateSBTask(Box box)
        {
            var tt = _ttService.TTGet();
            var ts = _tsService.TSQueued();
            var user = _userService.Get("user1");
            var b = box;
            double[] command = { 1500, b.AddressCol, b.AddressRow };
            var task = new SBTask();
            task.SBTaskStatusID = ts.SBTaskStatusID;
            task.SBTaskTypeID = tt.SBTaskTypeID;
            task.UserID = user.UserID;
            task.UserName = user.UserName;
            task.BoxID = b.BoxID;
            task.Command = command;
            _context.SBTasks.Add(task);
            _context.SaveChanges();
            return task;
        }


    }
}
