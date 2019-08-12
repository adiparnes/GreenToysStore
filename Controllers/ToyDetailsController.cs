using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GreenToys.Models;
using Microsoft.AspNet.Identity;
using GreenToys.Utility;
using GreenToys.ViewModel;

namespace GreenToys.Controllers
{
    public class ToyDetailsController : Controller
    {
        private static int animaldollsconter = 0;
        private static int barbie = 0;
        private static int lego = 0;
        private static int puzzle = 0;
        private static int musialinstrument = 0;
        private ApplicationDbContext db;
        public ToyDetailsController()
        {
            db =ApplicationDbContext.Create();
        }

        // GET: ToyDetails
        public ActionResult Index(int id,int? suggest)
        {

            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u=>u.Id==userid);
            
            //TypeOfToyid????
            var toyModel = db.Toys.Include(b => b.TypeOfToy).SingleOrDefault(b => b.ToyID == id);
            var ourToy = db.Toys.Where(t => t.ToyID == id);
            ViewBag.Toys = db.Toys.Where(t => t.TypeOfToyID == toyModel.TypeOfToyID).Except(ourToy).ToList();
            int type = toyModel.TypeOfToyID;
            if (type == 16)
            {
                animaldollsconter++;
                ViewBag.Count = animaldollsconter;
            }
            else if (type == 15)
            {
                musialinstrument++;
                ViewBag.Count = musialinstrument;
            }
            else if (type == 14)
            {
                puzzle++;
                ViewBag.Count = puzzle;
            }
            else if (type == 13)
            {
                barbie++;
                ViewBag.Count = barbie;
            }
            else if (type == 12)
            {
                lego++;
                ViewBag.Count = lego;
            }

            if (suggest == null)
            {
                ViewBag.Suggest = 0;
            }
            else
            {
                ViewBag.Suggest = 1;
            }

            var rentalPrice = 0.0;
            var oneMonthRental = 0.0;

            if (user != null&&!User.IsInRole(StatisDetails.AdminUserRole))
            {
                var ChargeRate = from u in db.Users
                                 join m in db.MembershipTypes
                                 on u.MembershipTypeID equals m.MembershipTypeID
                                 where u.Id.Equals(userid)
                                 select new { m.ChargeRateForOneMonth };

                oneMonthRental = Convert.ToDouble(toyModel.Price) * Convert.ToDouble(ChargeRate.ToList()[0].ChargeRateForOneMonth) / 100;

            }
            ToyRentalViewModel model = new ToyRentalViewModel
            {
                ToyID = toyModel.ToyID,
                Avaibility=toyModel.Avaibility,
                YearOfManufactire=toyModel.YearOfManufactire,
                ToyDescription=toyModel.ToyDescription,
                TypeOfToy=db.ToysType.FirstOrDefault(g=>g.TypeOfToyID.Equals(toyModel.TypeOfToyID)),
                TypeOfToyID=toyModel.TypeOfToyID,
                ImageUrl=toyModel.ImageUrl,
                Price=toyModel.Price,
                NameOfToy=toyModel.NameOfToy,
                ForAge=toyModel.ForAge,
                UserId=userid,
                ToyPrice=rentalPrice,
                RentalPriceOneMonth=oneMonthRental,


            };

            return View(model);
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