using StorageBoxes.Models;
using StorageBoxes.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StorageBoxes.Contracts.Tasks
{
    public interface ITaskService
    {
        //SBTaskType GetTTByName(string name);
        //SBTaskStatus GetTSByName(string name);
        SBTask CreateSBTask(Box box);
    }
}
