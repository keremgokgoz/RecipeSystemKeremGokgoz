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
    public class RecipesController : Controller
    {

        [HttpGet]
        public ActionResult Index() //Select
        {
            RecipesEntities entities = new RecipesEntities();
            var item = entities.RecipesTables.ToList();
            //var xx = from rec in entities.RecipesTables.Take(10) select rec;
            return View(item);
       

        }

        [HttpPost]
        public ActionResult Index(RecipesTable recipesTable) //Select
        {
            //RecipesEntitiesList recipesList = new RecipesEntitiesList();
            RecipesEntities entities = new RecipesEntities();
            var query = from rec in entities.RecipesTables.Take(10) select rec;
            return View(query);
            //
            //RecipesEntities entities = new RecipesEntities();
            //var query = from e in entities.RecipesTables
            //            select e;
            ////var query = entities.RecipesTables.FirstOrDefault(x => x.RecId == id);
            //return View(query);

        }

        [HttpGet]
        public ActionResult Add() //Create
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RecipesTable recipesTable) //Create
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                entities.RecipesTables.Add(recipesTable);

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
        public ActionResult Update(int id, RecipesTable recipesTable)
        {
            using (RecipesEntities entities = new RecipesEntities())
            {
                var query = entities.RecipesTables.FirstOrDefault(x => x.RecId == id);

                if (query != null)
                {
                    query.RecId         = recipesTable.RecId;
                    query.UserId        = recipesTable.UserId;
                    query.CatId         = recipesTable.CatId;
                    query.RecTitle      = recipesTable.RecTitle;
                    query.Images        = recipesTable.Images;
                    query.RecDetails    = recipesTable.RecDetails;

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
                var query = entities.RecipesTables.FirstOrDefault(x => x.RecId == id);

                if (query != null)
                {
                    entities.RecipesTables.Remove(query);
                    entities.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }


    }
}
