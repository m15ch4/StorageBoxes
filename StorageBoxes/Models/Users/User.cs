using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models.Users
{
    public class User
    {
        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RFID { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        public Role Role { get; set; }
    }
}
