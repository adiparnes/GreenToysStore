using GreenToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenToys.ViewModel
{
    public class ToyViewModel
    {
        public IEnumerable<TypeOfToy> TypeOfToys { get; set; }

        public Toy Toy { get; set; }
    }
}