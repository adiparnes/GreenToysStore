using GreenToys.Models;
using GreenToys.Utility;
using GreenToys.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace GreenToys.Controllers
{
    public class ToyRentController : Controller
    {

        private ApplicationDbContext db;

        public ToyRentController()
        {
            db = ApplicationDbContext.Create();
        }

        public ActionResult Create(string toyName = null, string toyDescription = null)
        {
            if (toyName != null && toyDescription != null)
            {
                ToyRentalViewModel model = new ToyRentalViewModel
                {
                    NameOfToy = toyName,
                    ToyDescription = toyDescription
                };
                return View(model);
            }


            return View(new ToyRentalViewModel());
        }

        //post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToyRentalViewModel toyRent)
        {
            if (ModelState.IsValid)
            {


                //return View(uvm);   

                var email = toyRent.Email;

                var userDetails = from u in db.Users
                                  where u.Email.Equals(email)
                                  select new { u.Id };//,u.FirstName,u.LastName,u.BirthDate
                //-------------------------------------isbn!!!!!!

                var toyName = toyRent.NameOfToy;
                Toy toySelected = db.Toys.Where(t => t.NameOfToy == toyName).FirstOrDefault();
                var rentalDuration = toyRent.RentalDuration;

                //List<UserViewModel> users = new List<UserViewModel>();
                //List<MembershipType> member = new List<MembershipType>();
             


                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes
                                 on u.MembershipTypeID equals m.MembershipTypeID
                                 where u.Email.Equals(email)
                                 select new { m.ChargeRateForOneMonth };

                var oneMonthRental = Convert.ToDouble(toySelected.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateForOneMonth) / 100;

                double rentalPrice = oneMonthRental;

                ToyRent modelToAddTodb = new ToyRent
                {
                    ToyID = toySelected.ToyID,
                    ToyPrice = rentalPrice,
                    ScheduledOfRentalDate = toyRent.ScheduledOfRentalDate,
                    RentalDuration=rentalDuration,
                    Status = ToyRent.StatusEnum.Approved,
                    UserId = userDetails.ToList()[0].Id

                };

                toySelected.Avaibility -= 1;
                db.ToyRents.Add(modelToAddTodb);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View();
        }




        // GET: ToyRent
        public ActionResult Index(int? pageNumber,string option=null,string search=null)
        {
            string userId = User.Identity.GetUserId();

            var model = from tr in db.ToyRents
                        join t in db.Toys
                        on tr.ToyID equals t.ToyID
                        join u in db.Users
                        on tr.UserId equals u.Id
                        select new ToyRentalViewModel
                        {
                            ToyID = t.ToyID,
                            ToyPrice = tr.ToyPrice,
                            Price = t.Price,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            BirthDate = u.BirthDate,
                            ScheduledOfRentalDate = tr.ScheduledOfRentalDate,
                            Avaibility = t.Avaibility,
                            YearOfManufactire = t.YearOfManufactire,
                            ToyDescription = t.ToyDescription,
                            Email = u.Email,
                            TypeOfToyID = t.TypeOfToyID,
                            TypeOfToy = db.ToysType.Where(m => m.TypeOfToyID.Equals(t.TypeOfToyID)).FirstOrDefault(),
                            ForAge = t.ForAge,
                            ImageUrl = t.ImageUrl,
                            RentalDuration = tr.RentalDuration,
                            Status = tr.Status.ToString(),
                            NameOfToy = t.NameOfToy,
                            UserId = u.Id,
                            ToyRentID = tr.ToyRentID,
                            StartOfRentalDate = tr.StartOfRentalDate

                        };
            if (option == "email" && search.Length > 0)
            {
                model = model.Where(u => u.Email.Contains(search));
            }
            if (option == "name" && search.Length > 0)
            {
                model = model.Where(u => u.FirstName.Contains(search)||u.LastName.Contains(search));
            }
            if (option == "status" && search.Length > 0)
            {
                model = model.Where(u => u.Status.Contains(search));
            }


            //not admin user can see only himself
            if (!User.IsInRole(StatisDetails.AdminUserRole))
            {
                model = model.Where(u => u.UserId.Equals(userId));
            }

            //each page 5 rows-----------------------
            return View(model.ToList().ToPagedList(pageNumber?? 1,5));
        }


        [HttpPost]
        public ActionResult Reserve(ToyRentalViewModel toy)
        {
            var userId = User.Identity.GetUserId();
            Toy toyToRent = db.Toys.Find(toy.ToyID);
            //double rentalPr = 0;
            double rentalPrice=0;
            if (userId != null)
            {

                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes
                                 on u.MembershipTypeID equals m.MembershipTypeID
                                 where u.Id.Equals(userId)
                                 select new { m.ChargeRateForOneMonth };

                //if(toy.RentalDuration==StatisDetails)

                var oneMonthRental = Convert.ToDouble(toyToRent.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateForOneMonth) / 100;

                rentalPrice = oneMonthRental;

            }
            ToyRent toyRent = new ToyRent
            {
                ToyID=toyToRent.ToyID,
                UserId=userId,
                RentalDuration=toy.RentalDuration,
                ToyPrice= rentalPrice,
                Status=ToyRent.StatusEnum.Requested
            };

            db.ToyRents.Add(toyRent);

            var toyInDb = db.Toys.SingleOrDefault(c => c.ToyID == toy.ToyID);
            toyInDb.Avaibility -= 1;
            db.SaveChanges();
            return RedirectToAction("Index", "ToyRent");
            
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            //base.Dispose(disposing);
        }
    }
}