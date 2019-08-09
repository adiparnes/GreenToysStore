using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenToys.Models
{
    public class ToyRent
    {

        public int ToyRentID { get; set; }

        public string UserId { get; set; }

        public int ToyID { get; set; }

        public DateTime? StartOfRentalDate{ get; set; }
        public DateTime? EndOfRentalDate { get; set; }
        public DateTime? ScheduledOfRentalDate { get; set; }

        public double? AdditionalCharge { get; set; }
        public double ToyPrice { get; set; }

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