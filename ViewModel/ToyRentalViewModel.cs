using GreenToys.Models;
using GreenToys.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static GreenToys.Models.ToyRent;

namespace GreenToys.ViewModel
{
    public class ToyRentalViewModel
    {
        
        public int ToyRentID { get; set; }





        // Book details
        public int ToyID { get; set; }     
        public string ToyDescription { get; set; }   
        public string NameOfToy { get; set; }
        public int ForAge { get; set; }
       
        [DataType(DataType.Currency)]
        public double Price { get; set; }
      
        public int TypeOfToyID { get; set; }
        
        [DataType(DataType.ImageUrl)]//it will make sure that it will not fall in the db
        public string ImageUrl { get; set; }
       
        [Range(0, 1000)]//range the number for each toy
        public int Avaibility { get; set; }

        [DisplayName("Date of manufacture")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime YearOfManufactire { get; set; }
        public TypeOfToy TypeOfToy { get; set; }





        // Rental Details
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime? StartOfRentalDate { get; set; }

        [DisplayName("Actual End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime? EndOfRentalDate { get; set; }

        [DisplayName("Scheduled End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime? ScheduledOfRentalDate { get; set; }

        [DisplayName("Additional Charge")]
        public double? AdditionalCharge { get; set; }

        [DisplayName("Toy rental price")]
        public double ToyPrice { get; set; } 
                  
        public string RentalDuration { get; set; }

        public string Status { get; set; }

        public double RentalPriceOneMonth { get; set; }



        // User details
        public string UserId { get; set; }
        public string Email { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Name { get { return FirstName + "" + LastName; }}

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime BirthDate { get; set; }

        public string actionName
        {
            get
            {
                if(Status.ToLower().Contains(StatisDetails.RequestedLower)){
                    return "Approve";
                }
                if (Status.ToLower().Contains(StatisDetails.ApprovedLower))
                {
                    return "PickUp";
                }
                if (Status.ToLower().Contains(StatisDetails.RentedLower))
                {
                    return "Return";
                }
                return null;
            }
        }

    }
}