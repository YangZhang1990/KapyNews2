using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KapyNews2.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserAccount>userAccount { get; set; }

    }
}