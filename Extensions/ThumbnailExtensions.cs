using GreenToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenToys.Extensions
{
    public static class ThumbnailExtensions
    {
        //return a list of thumbnails
        public static IEnumerable<ThumbnailModle> GetToyThumbnail(this List<ThumbnailModle> thumbnails, ApplicationDbContext db = null,string search=null)
        {
            try
            {
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }
                thumbnails = (from b in db.Toys
                              select new ThumbnailModle
                              {
                                  ToyID = b.ToyID,     
                                  ToyName=b.NameOfToy,                            
                                  ToyDescription=b.ToyDescription,
                                  TypeOfToy = b.TypeOfToy,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/ToyDetails/Index?id=" + b.ToyID
                              }).ToList();
                if (search != null)
                {
                    return thumbnails.Where(t => t.TypeOfToy.Name.ToLower().Contains(search.ToLower())).OrderBy(t => t.ToyID);
                    //return thumbnails.Where(t => t.TypeOfToy.Name.ToLower().Contains(search.ToLower())).OrderBy(t => t.ToyID);
                }
            }
            catch (Exception ex)
            {

            }
            return thumbnails.OrderBy(b => b.ToyID);
        }
    }
}