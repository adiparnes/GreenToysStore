using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenToys.Models
{
    public class MembershipType
    {
        [Required]
        public int MembershipTypeID { get; set; }

        [Required]
        public string MembershipName{ get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public byte SignUp { get; set; }

        [Required]
        public Byte ChargeRateForOneMonth { get; set; }
    }
}