using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {
        // GET: SuperHero
        ApplicationDbContext context;
        
        public SuperHeroController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var allHeros = context.superheros.ToList();
            return View(allHeros);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero SuperheroView = context.superheros.Where(c => c.Id == id).Single();
            return View(SuperheroView);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero SuperHero = new SuperHero();
            return View(SuperHero); 
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.superheros.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superheroToUpdate = context.superheros.Where(s => s.Id == id).Single();
            return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here
                SuperHero superheroToUpdate = context.superheros.Where(s => s.Id == id).Single();
                superheroToUpdate.superheroName = superHero.superheroName;
                superheroToUpdate.alteregofirstName = superHero.alteregofirstName;
                superheroToUpdate.alteregolastName = superHero.alteregolastName;
                superheroToUpdate.primaryAbility = superHero.primaryAbility;
                superheroToUpdate.primaryAbility = superHero.secondaryAbility;
                superheroToUpdate.catchPhrase = superHero.catchPhrase;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superheroToRemove = context.superheros.Where(s => s.Id == id).Single();
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                SuperHero superheroToRemove = context.superheros.Where(s => s.Id == id).Single();
                context.superheros.Remove(superheroToRemove);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch   
            {
                return View(superHero);
            }
        }
    }
}
