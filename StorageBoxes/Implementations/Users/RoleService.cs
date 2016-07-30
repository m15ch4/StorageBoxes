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
    class RoleService : IRoleService
    {
        private SBContext _context;

        public RoleService()
        {
            _context = new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }

        public Role Get(string roleName)
        {
            return _context.Roles.Where(r => r.RoleName == roleName).FirstOrDefault();
        }

        public ICollection<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}
