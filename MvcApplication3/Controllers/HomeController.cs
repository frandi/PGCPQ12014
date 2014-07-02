using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string id, string name)
        {
            ViewBag.ItemId = id;
            ViewBag.Name = name;
            return View();
        }

        public ActionResult FrontPage()
        {
            return View();
        }

        [NonAction]
        public ActionResult IndexAlias()
        {
            ViewBag.ItemId = "100000000000000000";
            ViewBag.Name = "aLIAS";
            return View("Index");
        }

        public ActionResult Login()
        {
            var departments = new List<string>() { "Accounting", "Finance", "SE" };
            //ViewBag.Departments = departments;

            var user = new Person() { Username = "", Department = "SE", DepartmentList = new SelectList(departments) };

            return View(user);
        }

        [HttpPost]
        public ActionResult Login(Person user, string gender)
        {
            if (ModelState.IsValid)
            {
                if (user.Username == "david" && user.Password == "mitrais")
                    ViewBag.Status = "Success! (" + user.Department + ") - " + gender;
                else
                    ViewBag.Status = "Failed! (" + user.Department + ") - " + gender;

                var departments = new List<string>() { "Accounting", "Finance", "SE" };
                user.DepartmentList = new SelectList(departments);

                return View(user);
            }
            else
            {
                var departments = new List<string>() { "Accounting", "Finance", "SE" };
                user.DepartmentList = new SelectList(departments);

                ViewBag.Error = "Error";
                return View(user);
            }
        }

        public ActionResult UserList()
        {
            var users = new List<Person>()
            {
                new Person() { Username = "Prabowo", Department = "Gerindra" },
                new Person() { Username = "Jokowi", Department = "PDIP" }
            };

            return View(users);
        }
    }
}
