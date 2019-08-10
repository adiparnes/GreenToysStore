using GreenToys.Models;
using GreenToys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GreenToys.Controllers.Api
{
    public class ToyApiController : ApiController
    {
        private ApplicationDbContext db;

        public ToyApiController()
        {
            db = ApplicationDbContext.Create();
        }

        //name of toy
        public IHttpActionResult Get(string query=null)
        {
            var toyQuery = db.Toys.Where(t => t.NameOfToy.ToLower().Contains(query.ToLower()));
            return Ok(toyQuery.ToList());
        }



        //price on Avialability (price/avail)
        public IHttpActionResult Get(string type,string name=null,string rentalDuration=null,string email=null)
        {
            if (type.Equals("price"))
            {
                Toy toyQuery = db.Toys.Where(t => t.NameOfToy.Equals(name)).SingleOrDefault();

                var ChargeRate = from u in db.Users
                                 join m in db.MembershipTypes
                                 on u.MembershipTypeID equals m.MembershipTypeID
                                 where u.Email.Equals(email)
                                 select new {m.ChargeRateForOneMonth };
                var price = Convert.ToDouble(toyQuery.Price) * Convert.ToDouble(ChargeRate.ToList()[0].ChargeRateForOneMonth) / 100;
                //if (rentalDuration == StatisDetails.OneMonthCount)
                //{
                //    price = Convert.ToDouble(toyQuery.Price) * Convert.ToDouble(ChargeRate.ToList()[0].ChargeRateForOneMonth) / 100;
                //}
                return Ok(price);
            }
            else
            {
                //-----------------------------null
                Toy toyQuery = db.Toys.Where(t => t.NameOfToy.Equals(name)).SingleOrDefault();
                return Ok(toyQuery.Avaibility);

            }
            //return Ok(toyQuery.ToList());
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
