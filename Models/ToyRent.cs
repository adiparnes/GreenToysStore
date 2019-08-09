using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenToys.Models
{
    public class ToyRent
    {
        [Required]
        public int ToyRentID { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ToyID { get; set; }

        public DateTime? StartOfRentalDate{ get; set; }
        public DateTime? EndOfRentalDate { get; set; }
        public DateTime? ScheduledOfRentalDate { get; set; }

        public double? AdditionalCharge { get; set; }

        [Required]
        public double ToyPrice { get; set; }

        [Required]
        public string RentalDuration { get; set; }

        [Required]
        public StatusEnum Status { get; set; }

        public enum StatusEnum
        {
            Requested,
            Approved,
            Rejected,
            Rented,
            closed,

        }
    }
}