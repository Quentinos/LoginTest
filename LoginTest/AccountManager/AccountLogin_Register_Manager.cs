using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoginTest.AccountManager
{
    public class AccountLogin_Register_Manager
    {
        public static Account UserRegister(Account newAccount)
        {
            byte[] passwordbyte = Encoding.ASCII.GetBytes(newAccount.Password);
            byte[] passwordsalt = AccountSecurity.GenerateSalt(16);
            byte[] passwordhash = AccountSecurity.GenerateHash(passwordbyte, passwordsalt, 10000, 16);
            newAccount.PasswordSalt = passwordsalt;
            newAccount.PasswordHash = passwordhash;
            newAccount.ConfirmPassword = newAccount.ConfirmPassword;
            newAccount.CreatedOn = DateTime.Now;
            return newAccount;
        }
    }
}