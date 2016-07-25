using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.Models
{
    public class MigrationsContextFactory : IDbContextFactory<SBContext>
    {
        SBContext IDbContextFactory<SBContext>.Create()
        {
            return new SBContext("StorageBoxes.Properties.Settings.SBDBConnectionString");
        }
    }
}
