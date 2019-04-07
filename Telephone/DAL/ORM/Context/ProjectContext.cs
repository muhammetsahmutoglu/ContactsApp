using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephone.DAL.ORM.Entity;

namespace Telephone.DAL.ORM.Context
{
    class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=MONSTER;DataBase=Contacts;UID=sa;PWD=1234;";
        }
        public DbSet<AppUser> AppUsers { get; set; }

     

    }
}
