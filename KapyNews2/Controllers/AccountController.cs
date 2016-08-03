using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KapyNews2.Models;

namespace KapyNews2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        //add a method for registration
        public ActionResult Register()
        {
            return View();
        }

        //to perform the task
        //pass useAccount as a parameter
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.userId + " is successfully registered.";
            }
            return View();
                
        }

        //add a method for log in
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var usr = db.userAccount.Single(u => u.userName == user.userName && u.password == user.password);
                if (usr != null)
                {
                    Session["userID"] = usr.userId.ToString();
                    Session["userName"] = user.userName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        //add a method for log in page
        public ActionResult LoggedIn()
        {
            if(Session["userID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
    }
}