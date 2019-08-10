using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;//import to requried
using System.Linq;
using System.Web;

namespace GreenToys.Models
{
    public class Toy
    {
        [Required]//have to enter a value
        public int ToyID { get; set; }

        [Required]
        public string ToyDescription { get; set; }

        [Required]
        public string NameOfToy { get; set; }

        [Required]
        public int ForAge { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        public int TypeOfToyID{ get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]//it will make sure that it will not fall in the db
        public string ImageUrl{ get; set; }

        [Required]
        [Range(0,1000)]//range the number for each toy       
        public int Avaibility{ get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: MMM dd yyyy}")]
        public DateTime YearOfManufactire{ get; set; }

        public TypeOfToy TypeOfToy { get; set; }
    }
}