using StorageBoxes.Contracts.Users;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageBoxes.Models.Users;

namespace StorageBoxes.Implementations.Users
{
    class UserService : IUserService
    {
        private SBContext _context;

        public UserService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public User Get(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
