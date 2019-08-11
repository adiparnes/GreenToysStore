using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenToys.Models;
using GreenToys.ViewModel;
using GreenToys.Utility;

namespace GreenToys.Controllers
{
    // [Authorize] only login requested
    //[Authorize(Roles=StatisDetails.AdminUserRole)] only admin can get there
    [Authorize(Roles=StatisDetails.AdminUserRole)]
    public class ToysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Toys
        public ActionResult Index()
        {
            //return View(db.Toys.ToList());
            var toys = db.Toys.Include(t => t.TypeOfToy);// Making a list from the db and
            //passing it to the view
            //include-import entity
            return View(toys.ToList());
        }

        // GET: Toys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }

            var model = new ToyViewModel
            {
                Toy = toy,
                TypeOfToys = db.ToysType.ToList()
            };
            return View(model);
        }

        // GET: Toys/Create
        public ActionResult Create()
        {
            // ViewBag.TypeOfToyID = new SelectList(db.ToysType, "TypeOfToyID", "Name");
            var typeoftoy = db.ToysType.ToList();
            var model = new ToyViewModel
            {
                TypeOfToys = typeoftoy

            };
            return View(model);
        }

        // POST: Toys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToyViewModel toyVM)//[Bind(Include = "ToyID,ForAge,Price,TypeOfToyID,ImageUrl,Avaibility,YearOfManufactire")]
        {

            var toy = new Toy
            {
                NameOfToy=toyVM.Toy.NameOfToy,
                Price = toyVM.Toy.Price,
                ForAge=toyVM.Toy.ForAge,
                ToyDescription=toyVM.Toy.ToyDescription,
                Avaibility=toyVM.Toy.Avaibility,
                ImageUrl=toyVM.Toy.ImageUrl,
                YearOfManufactire=toyVM.Toy.YearOfManufactire,
                //ToyID=toyVM.Toy.ToyID,
                TypeOfToyID=toyVM.Toy.TypeOfToyID,
                TypeOfToy=toyVM.Toy.TypeOfToy
            };

            if (ModelState.IsValid)
            {
                db.Toys.Add(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //var model = new ToyViewModel
            //{
            //    Toy = toy,
            //    TypeOfToys = db.ToysType.ToList()
            //};

            // ViewBag.TypeOfToyID = new SelectList(db.ToysType, "TypeOfToyID", "Name", toy.TypeOfToyID);

            toyVM.TypeOfToys = db.ToysType.ToList();
            return View(toyVM);
        }

        // GET: Toys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            var model = new ToyViewModel
            {
                Toy = toy,
                TypeOfToys = db.ToysType.ToList()
            };
           // ViewBag.TypeOfToyID = new SelectList(db.ToysType, "TypeOfToyID", "Name", toy.TypeOfToyID);
            return View(model);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] //if there is description
        public ActionResult Edit(ToyViewModel toyVM)//[Bind(Include = "ToyID,ForAge,Price,TypeOfToyID,ImageUrl,Avaibility,YearOfManufactire")]
        {
            var toy = new Toy
            {
                ToyID = toyVM.Toy.ToyID,
                NameOfToy = toyVM.Toy.NameOfToy,
                Price = toyVM.Toy.Price,
                ToyDescription = toyVM.Toy.ToyDescription,
                ForAge = toyVM.Toy.ForAge,
                Avaibility = toyVM.Toy.Avaibility,
                ImageUrl = toyVM.Toy.ImageUrl,
                YearOfManufactire = toyVM.Toy.YearOfManufactire,                
                TypeOfToyID = toyVM.Toy.TypeOfToyID,
                TypeOfToy = toyVM.Toy.TypeOfToy
            };

            if (ModelState.IsValid)
            {
                db.Entry(toy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            toyVM.TypeOfToys = db.ToysType.ToList();
            // ViewBag.TypeOfToyID = new SelectList(db.ToysType, "TypeOfToyID", "Name", toy.TypeOfToyID);
            return View(toy);// return View(toyVM);
        }

        // GET: Toys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            var model = new ToyViewModel
            {
                Toy = toy,
                TypeOfToys = db.ToysType.ToList()
            };
            return View(model);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]//because the name of the func is not delete, let mvc now its delete
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)//delete due to id
        {
            Toy toy = db.Toys.Find(id);
            db.Toys.Remove(toy);
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
