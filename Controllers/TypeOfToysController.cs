using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenToys.Models;

namespace GreenToys.Controllers
{
    public class TypeOfToysController : Controller
    {
        private ApplicationDbContext db;
        public TypeOfToysController()
        {
            db= new ApplicationDbContext();
        }

        // GET: TypeOfToys
        public ActionResult Index()
        {
            
            //return View(db.ToysType.ToList());
            return View(db.ToysType.ToList());
        }

        public ActionResult groupBy(TypeOfToy type)
        {
            var toys = db.Toys.GroupBy(toy => toy.TypeOfToyID.Equals(type.TypeOfToyID));
                  
            return View(toys.ToList());
        }

        // GET: TypeOfToys/Details/5
        //general id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TypeOfToy typeOfToy = db.ToysType.Find(id);// find me a toytype where id is
            //equal to what we are passing

            if (typeOfToy == null)
            {
                return HttpNotFound();
            }
            return View(typeOfToy);
        }

        // GET: TypeOfToys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfToys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] // Letting the mvc know this is a post action
        [ValidateAntiForgeryToken]//we used it in the view
        public ActionResult Create(TypeOfToy typeOfToy)//([Bind(Include = "TypeOfToyID,Name")]TypeOfToy typeOfToy)
        {
            // ModelState- once we add all the required --
            //-- attributs from the modle then it will be valid
            if (ModelState.IsValid)
            {
                db.ToysType.Add(typeOfToy); // Add the toy to the db
                db.SaveChanges();
                return RedirectToAction("Index");
                // We wants to desplay the index --
                //-- view wite the new toy that was added

            }

            return View(typeOfToy);
        }

        // GET: TypeOfToys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfToy typeOfToy = db.ToysType.Find(id);
            if (typeOfToy == null)
            {
                return HttpNotFound();
            }
            return View(typeOfToy);
        }

        // POST: TypeOfToys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TypeOfToy typeOfToy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfToy).State = EntityState.Modified;//if the typeOfToy is the same 
                //that we are searching it will update the data base
                //one col not expensive
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfToy);
        }

        // GET: TypeOfToys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfToy typeOfToy = db.ToysType.Find(id);
            if (typeOfToy == null)
            {
                return HttpNotFound();
            }
            return View(typeOfToy);
        }

        // POST: TypeOfToys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfToy typeOfToy = db.ToysType.Find(id);
            db.ToysType.Remove(typeOfToy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
