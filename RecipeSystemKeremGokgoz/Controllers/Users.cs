using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using RecipeSystemKeremGokgoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Web.Routing;

namespace RecipeSystemKeremGokgoz.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet]
        public ActionResult Index() //Select
        {
            RecipesEntities entities = new RecipesEntities();
            var query = from e in entities.UsersTables
                        select e;
            //var query = entities.RecipesTables.FirstOrDefault(x => x.RecId == id);

            return View(query);
        }

        [HttpGet]
        public ActionResult Add() //Create
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsersTable usersTable) //Create
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                entities.UsersTables.Add(usersTable);

                entities.SaveChanges();
            }
            string message = "Created the record successfully";

            ViewBag.Message = message;

            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, UsersTable usersTable)
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                var query = entities.UsersTables.FirstOrDefault(x => x.UserId == id);

                if (query != null)
                {
                    query.UserId    = usersTable.UserId;
                    query.Name      = usersTable.Name;
                    query.Mail      = usersTable.Mail;
                    query.Password  = usersTable.Password;

                    entities.SaveChanges();

                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                var query = entities.UsersTables.FirstOrDefault(x => x.UserId == id);

                if (query != null)
                {
                    entities.UsersTables.Remove(query);
                    entities.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }


    }
}
