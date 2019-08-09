using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenToys.ViewModel;
using GreenToys.Extensions;
using GreenToys.Models;

namespace GreenToys.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search=null) // The index of home page, will send you to the view of index-home
        {
            var thumbnails = new List<ThumbnailModle>().GetToyThumbnail(ApplicationDbContext.Create(),search);
            var count = thumbnails.Count()/4;
            var model = new List<ThumbnailBoxViewModel>();

            for(int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel//list 4 on 4 thumbnails
                {
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }

            return View(model); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}