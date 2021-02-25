using LoginTest.AccountManager;
using LoginTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LoginTest.Models
{
    public class Dal : IDal
    {
        AccountContext bdd;

        public Dal()
        {
            bdd = new AccountContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public async Task<bool> Register(Account account)
        {
            var accountt = AccountLogin_Register_Manager.UserRegister(account);

            if (account.PasswordHash != null && account.PasswordSalt != null)
            {
                bdd.Accounts.Add(account);
                await bdd.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}