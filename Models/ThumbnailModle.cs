using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenToys.Models
{
    public class ThumbnailModle
    {
        public int ToyID { get; set; }
        public string ToyName { get; set; }
        public TypeOfToy TypeOfToy { get; set; }
        public Toy Toy { get; set; }
        public string ToyDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}