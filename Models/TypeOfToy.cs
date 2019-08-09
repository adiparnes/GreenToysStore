using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Web;

namespace GreenToys.Models
{
    public class TypeOfToy
    {
        [Required]
        public int TypeOfToyID { get; set; }

        [Required]
        public string ToyDescription{ get; set; }

        [Required]
        [DisplayName("All of the type of toys")]
        public string Name { get; set; }
    }
}