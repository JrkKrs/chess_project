using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

//using WebApplication.Models;

namespace WebApplication.Controllers
{

    public class HomeController : Controller
    {


        private string CalculateSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(str));

            string hashValuestr = Encoding.Default.GetString(hashValue);

            return hashValuestr;
        }



        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";
            return View();
        }

        // POST: Home/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "username,passwd")] users users)
        {
            if (ModelState.IsValid)
            {
                users.passwd = CalculateSHA256(users.passwd);
                var row = db.users
                    .Where(user => user.username == users.username)
                    .Where(user => user.passwd == users.passwd)
                    .FirstOrDefault();
                if (row != null)
                {
                    Session["userId"] = row.id;
                    Session["displayName"] = row.displayName;

                    row.lastActive = DateTime.Now;
                    row.lastLogin = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    users.LoginMsgError = "Invalid login od password.";
                    return View("Login", users);
                }
            }

            return View(users);
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "username,displayName,passwd,passwdRepeat,email")]
            users users)
        {
            if (ModelState.IsValid)
            {
                var row = db.users
                    .Where(user => user.username == users.username || user.email == users.email)
                    .FirstOrDefault();
                if (row == null)
                {
                    if (users.passwd == users.passwdRepeat)
                    {
                        users.registerDate = DateTime.Now;
                        users.passwd = CalculateSHA256(users.passwd);
                        db.users.Add(users);
                        db.SaveChanges();

                        users.registerMsg = "Registration OK, Now you can login.";
                        TempData["Success"] = "Registration OK, Now you can login.";
                        return RedirectToAction("Index", users);
                    }
                    else
                    {
                        users.LoginMsgError = "Password is not identical .";
                        return View("Login", users);
                    }
                }
                else
                {
                    users.LoginMsgError = "Login od email is used.";
                    return View("Login", users);
                }
            }

            return View(users);
        }

        public ActionResult MyGames()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}