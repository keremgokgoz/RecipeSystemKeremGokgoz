using RecipeSystemKeremGokgoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecipeSystemKeremGokgoz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UsersTable usersTable)
        {
            if (ModelState.IsValid)
            {
                using (RecipesEntities entities = new RecipesEntities())
                {
                    // var obj = entities..Where(a => a.UserName.Equals(usersTable.UserName) && a.Password.Equals(usersTable.Password)).FirstOrDefault();
                    //var query = entities.RecipesTables.FirstOrDefault(x => x.RecId == id);
                    var query = entities.UsersTables.Where(u => u.Mail.Equals(usersTable.Mail) && u.Password.Equals(usersTable.Password)).FirstOrDefault();
                    if (query != null)
                    {
                        Session["UserId"] = query.UserId.ToString();
                        Session["Name"] = query.Mail.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(usersTable);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index"); //Login?
            }
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


    }
}

