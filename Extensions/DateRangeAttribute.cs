using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenToys.Extensions
{
    public class DateRangeAttribute: RangeAttribute
    {
        public DateRangeAttribute(string minValue) : base(typeof(DateTime), minValue, DateTime.Now.ToShortDateString())
        {

        }
    }
}