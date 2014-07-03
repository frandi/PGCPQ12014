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
        private AppContext _db = new AppContext();

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

            var user = new Person() { Username = "", DepartmentList = new SelectList(departments) };

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
            var users = _db.People.ToList();

            return View(users);
        }

        public ActionResult ViewUser(int id)
        {
            var user = _db.People.Include("Department").FirstOrDefault(p => p.PersonId == id);
            if (user == null)
                RedirectToAction("User");
            
            return View(user);
        }

        public ActionResult EditUser(int id)
        {
            var user = _db.People.Include("Department").FirstOrDefault(p => p.PersonId == id);
            if (user == null)
                RedirectToAction("User");

            user.DepartmentList = GetDepartmentList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(Person user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();

                    ViewBag.Message = "Success!";
                }
                else
                    throw new Exception("Model is not valid!");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed! " + ex.Message;
            }

            user.DepartmentList = GetDepartmentList();
            
            return View(user);
        }

        public ActionResult AddUser()
        {
            var user = new Person();
            user.DepartmentList = GetDepartmentList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(Person user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.People.Add(user);
                    _db.SaveChanges();

                    ViewBag.Message = "Success!";
                }
                else
                    throw new Exception("Model is not valid!");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed! " + ex.Message;
            }

            user.DepartmentList = GetDepartmentList();

            return View(user);
        }

        public ActionResult DeleteUser(int id)
        {
            var user = _db.People.Include("Department").FirstOrDefault(p => p.PersonId == id);
            if (user == null)
                return RedirectToAction("User");

            user.DepartmentList = GetDepartmentList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserNow(int id)
        {
            try
            {
                var user = _db.People.Find(id);
                if (user == null)
                    throw new Exception("User doesn't exist!");

                string username = user.Username;

                _db.People.Remove(user);
                _db.SaveChanges();

                ViewBag.Message = string.Format("Success! User {0} was deleted.", username);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed! " + ex.Message;
            }

            return RedirectToAction("UserList");
        }

        private SelectList GetDepartmentList()
        {
            var departments = _db.Departments.OrderBy(d => d.DepartmentName).ToList();
            return new SelectList(departments, "DepartmentId", "DepartmentName");
        }
    }
}
