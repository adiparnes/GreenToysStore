using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenToys.Models;
using GreenToys.ViewModel;
using GreenToys.Utility;

namespace GreenToys.Controllers
{
    [Authorize(Roles = StatisDetails.AdminUserRole)]
    public class UserViewModelsController : Controller
    {
        private ApplicationDbContext db;// = new ApplicationDbContext();

        public UserViewModelsController()
        {
            db = ApplicationDbContext.Create();
        }

        // GET: UserViewModels
        public ActionResult Index(string name=null)
        {

            var users = from u in db.Users
                        join m in db.MembershipTypes
                        on u.MembershipTypeID equals m.MembershipTypeID
                        select u;
            if (!String.IsNullOrEmpty(name))
            {
               users = users.Where(t => t.Email.Contains(name));
            }
            List<UserViewModel> uvm = new List<UserViewModel>();
            List<MembershipType> mem = db.MembershipTypes.ToList();
            foreach (var u in users)
            {
                uvm.Add(new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone,
                    BirthDate = u.BirthDate,
                    MembershipTypeID = u.MembershipTypeID,
                    MembershipTypes = mem.Where(n => n.MembershipTypeID.Equals(u.MembershipTypeID)).ToList(),
                    Disable = u.Disable
                    //MembershipTypes = (ICollection<MembershipType>)db.MembershipTypes.ToList(),
                });
            }
            return View(uvm);
        }

        // GET: UserViewModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            //UserViewModel userViewModel = db.UserViewModels.Find(id);
            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Id=user.Id,
                BirthDate = user.BirthDate,
                MembershipTypeID = user.MembershipTypeID,
                MembershipTypes = db.MembershipTypes.ToList(),
                Disable = user.Disable

            };

            return View(model);
        }

        // GET: UserViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(UserViewModel userViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserViewModels.Add(userViewModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(userViewModel);
        //}

        // GET: UserViewModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            //UserViewModel userViewModel = db.UserViewModels.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Id=user.Id,// change add ID
                BirthDate = user.BirthDate,
                Email = user.Email,
                MembershipTypeID = user.MembershipTypeID,
                MembershipTypes = db.MembershipTypes.ToList(),
                Disable = user.Disable

            };
            return View(model);
        }

        // POST: UserViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                UserViewModel model = new UserViewModel
                {
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Phone = userViewModel.Phone,
                    Id=userViewModel.Id,
                    MembershipTypeID = userViewModel.MembershipTypeID,
                    BirthDate = userViewModel.BirthDate,
                    Email = userViewModel.Email,
                    MembershipTypes = db.MembershipTypes.ToList(),
                    Disable = userViewModel.Disable

                };
                return View("Edit", model);
            }
            else
            {
                var userInDb = db.Users.Single(u => u.Id == userViewModel.Id);
                userInDb.FirstName = userViewModel.FirstName;
                userInDb.LastName = userViewModel.LastName;
                userInDb.Phone = userViewModel.Phone;
                userInDb.Email = userViewModel.Email;
                userInDb.BirthDate = userViewModel.BirthDate;
                userInDb.MembershipTypeID = userViewModel.MembershipTypeID;
                userInDb.Disable = userViewModel.Disable;

            }
            db.SaveChanges();
            return RedirectToAction("Index", "UserViewModels");
            //if (ModelState.IsValid)
            //{
            //    db.Entry(userViewModel).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //  return View(userViewModel);
        }

        // GET: UserViewModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                MembershipTypeID = user.MembershipTypeID,
                BirthDate = user.BirthDate,
                Email = user.Email,
                MembershipTypes = db.MembershipTypes.ToList(),
                Disable = user.Disable

            };

            return View(model);
        }

        // POST: UserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var userInDb = db.Users.Find(id);
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserViewModel userViewModel = db.UserViewModels.Find(id);
            // db.UserViewModels.Remove(userViewModel);
            userInDb.Disable = 1;
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
