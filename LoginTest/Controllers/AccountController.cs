using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginTest.Context;
using LoginTest.Models;
using LoginTest.AccountManager;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using LoginTest.ViewModels;
using System.Net;

namespace LoginTest.Controllers
{
    public class AccountController : Controller
    {
        AccountContext context = new AccountContext();
        private IDal dal;

        public AccountController() : this(new Dal())
        {

        }
        public AccountController(IDal daal)
        {
            dal = daal;
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.returnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login_View_Model account, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                Account tempAccount = context.Accounts.FirstOrDefault(u => u.Email == account.Email);
                if (tempAccount != null)
                {
                    byte[] tempPasswordbyte = Encoding.ASCII.GetBytes(account.Password);
                    byte[] tempPasswordhash = AccountSecurity.GenerateHash(tempPasswordbyte, tempAccount.PasswordSalt, 10000, 16);
                    if (tempPasswordhash.SequenceEqual(tempAccount.PasswordHash))
                    {
                        FormsAuthentication.SetAuthCookie(tempAccount.Id.ToString(), false);
                        if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                    }
                    ModelState.AddModelError("Email", "Incorrect Email or Password");
                    ModelState.AddModelError("Password", "Incorrect Email or Password");
                }
                else
                {
                    return Redirect("/");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Register()
        {
            Account objAccount = new Account();
            return View(objAccount);
        }

        [HttpPost]
        public async Task<ActionResult> Register(Account newAccount)
        {
            if (ModelState.IsValid)
            {
                var response = await dal.Register(newAccount);
                if (response)
                {
                    return View("Login");
                }
                return View(newAccount);
            }
            return View();
        }

        public ActionResult MyProfile()
        {
            int IdAccount = Int32.Parse(HttpContext.User.Identity.Name);
            return View(context.Accounts.FirstOrDefault(u => u.Id == IdAccount));
        }
    }
}