using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginTest.Context
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}