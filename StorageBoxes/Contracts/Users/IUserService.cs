using StorageBoxes.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Contracts.Users
{
    public interface IUserService
    {
        User Get(string userName);
    }
}
