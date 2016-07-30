using StorageBoxes.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models.Tasks
{
    public class SBTask
    {
        public int SBTaskID { get; set; }
        public int SBTaskTypeID { get; set; }
        public int SBTaskStatusID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public int BoxID { get; set; }
        public double[] Command { get; set; }


        public SBTaskType SBTaskType { get; set; }
        public SBTaskStatus SBTaskStatus { get; set; }
        public User User { get; set; }
        public Box Box { get; set; }
    }
}
