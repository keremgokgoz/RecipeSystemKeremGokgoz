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

namespace RecipeSystemKeremGokgoz.Controllers
{
    public class CategoriesController : Controller
    {

        [HttpGet]
        public ActionResult Index() //Select
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                var query = from e in entities.CategoriesTables
                            select e;
                //var query = entities.CategoriesTables.FirstOrDefault(x => x.RecId == id);

                return View(query);
            }
        }

        [HttpGet]
        public ActionResult Add() //Create
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoriesTable categoriesTables) //Create
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                entities.CategoriesTables.Add(categoriesTables);
                entities.SaveChanges();
            }
            string message = "Created the record successfully";
            ViewBag.Message = message;

            return View();
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Update()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, CategoriesTable categoriesTables)
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                var query = entities.CategoriesTables.FirstOrDefault(x => x.CatId == id);

                if (query != null)
                {
                    query.CatId = categoriesTables.CatId;
                    query.CatName = categoriesTables.CatName;
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
                var query = entities.CategoriesTables.FirstOrDefault(x => x.CatId == id);

                if (query != null)
                {
                    entities.CategoriesTables.Remove(query);
                    entities.SaveChanges();

                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }


    }
}
